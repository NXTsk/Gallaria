using Gallaria.ApiClient.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gallaria.ApiClient;
using Gallaria.WEB.Helpers;
using Microsoft.AspNetCore.Http;
using Gallaria.ApiClient.Interfaces;

namespace Gallaria.WEB.Controllers
{
    public class ArtController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IArtClient artClient;
        private IPersonClient personClient;

        public ArtController(IHttpContextAccessor httpContextAccessor, IArtClient _artClient, IPersonClient _personClient)
        {
            _httpContextAccessor = httpContextAccessor;
            artClient = _artClient;
            personClient = _personClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            ArtDto art = artClient.GetArtByIDAsync(id, CookieHelper.ReadJWT("X-Access-Token", _httpContextAccessor)).Result;
            var artist = personClient.GetPersonByIdAsync(art.AuthorId).Result;

            art.ArtistName = artist.FirstName + " " + artist.LastName;

            //Converting from basestring64 to image
            art.Img64 = GetImageSourceFromByteArray(art.Image);

            return View(art);
        }
        public IActionResult AllArts()
        {
            IEnumerable<ArtDto> artDtos = artClient.GetAllArtsAsync().Result;
            foreach (var art in artDtos)
            {
                var artist = personClient.GetPersonByIdAsync(art.AuthorId).Result;
                art.ArtistName = artist.FirstName + " " + artist.LastName;
                art.Img64 = GetImageSourceFromByteArray(art.Image);

            }

            return View(artDtos);
        }

        public string GetImageSourceFromByteArray(byte[] imgBytes)
        {
            string imreBase64Data = Convert.ToBase64String(imgBytes);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            return imgDataURL;
        }
    }
}

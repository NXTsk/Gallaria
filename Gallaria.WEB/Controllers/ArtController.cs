using Gallaria.ApiClient.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gallaria.ApiClient;
using Gallaria.WEB.Helpers;
using Microsoft.AspNetCore.Http;

namespace Gallaria.WEB.Controllers
{
    public class ArtController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;

        public ArtController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            ArtDto art = ApiClient.ArtController.GetArtByIDAsync(id, CookieHelper.ReadJWT("X-Access-Token", _httpContextAccessor)).Result;
            var artist = ApiClient.PersonController.GetPersonByIdAsync(art.AuthorId).Result;
            art.ArtistName = artist.FirstName + " " + artist.LastName;

            //Converting from basestring64 to image
            art.Img64 = GetImageSourceFromByteArray(art.Image);

            return View(art);
        }
        public IActionResult AllArts()
        {
            IEnumerable<ArtDto> artDtos = ApiClient.ArtController.GetAllArtsAsync().Result;
            foreach (var art in artDtos)
            {
                var artist = ApiClient.PersonController.GetPersonByIdAsync(art.AuthorId).Result;
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

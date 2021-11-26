using Gallaria.ApiClient.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gallaria.ApiClient;

namespace Gallaria.WEB.Controllers
{
    public class ArtController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            ArtDto art = ApiClient.ArtController.GetArtByIDAsync(id).Result;

            //Converting from basestring64 to image
            art.Image = "data:image/png;base64, " + art.Image;

            return View(art);
        }
        public IActionResult AllArts()
        {
            IEnumerable<ArtDto> artDtos = ApiClient.ArtController.GetAllArtsAsync().Result;
            foreach (var art in artDtos)
            {
                art.Image = "data:image/png;base64, " + art.Image;
            }

            return View(artDtos);
        }
    }
}

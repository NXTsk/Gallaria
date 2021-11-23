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

        public IActionResult ArtDetails(int id)
        {
            ArtDto art = ApiClient.ArtController.GetArtByIDAsync(id).Result;
            return View(art);
        }
    }
}

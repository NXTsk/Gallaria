    using Gallaria.ApiClient.DTOs;
using Gallaria.ApiClient.Interfaces;
using Gallaria.WEB.Helpers;
using Gallaria.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Gallaria.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHttpContextAccessor _httpContextAccessor;
        private IArtClient _artClient;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IArtClient artClient)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _artClient = artClient;
        }

        public IActionResult Index()
        {
            string JWT = CookieHelper.ReadJWT("X-Access-Token", _httpContextAccessor);
            IEnumerable<ArtDto> sampleArts = _artClient.GetAllAvailableArtsAsync().Result;
            var list = sampleArts.Reverse().Take(3);
            foreach (var item in list)
            {
                item.Img64 = GetImageSourceFromByteArray(item.Image);
            }

            if (JWT != null)
            {
                HttpContext.Session.SetString("isAuthenticated", "true");

            }
            else
            {
                HttpContext.Session.SetString("isAuthenticated", "false");
            }

            return View(list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel 
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            });
        }
        public string GetImageSourceFromByteArray(byte[] imgBytes)
        {
            string imreBase64Data = Convert.ToBase64String(imgBytes);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            return imgDataURL;
        }
    }
}

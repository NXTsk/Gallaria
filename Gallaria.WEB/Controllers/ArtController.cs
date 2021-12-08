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
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace Gallaria.WEB.Controllers
{
    public class ArtController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IArtClient _artClient;
        private IPersonClient _personClient;
        private OrderDto _orderDto;

        public ArtController(IHttpContextAccessor httpContextAccessor, IArtClient artClient, IPersonClient personClient)
        {
            _httpContextAccessor = httpContextAccessor;
            _artClient = artClient;
            _personClient = personClient;
            InitializeShoppingCartAndSaveInSession();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            ArtDto art = _artClient.GetArtByIDAsync(id).Result;
            var artist = _personClient.GetPersonByIdAsync(art.AuthorId).Result;

            art.ArtistName = artist.FirstName + " " + artist.LastName;

            //Converting from basestring64 to image
            art.Img64 = GetImageSourceFromByteArray(art.Image);

            return View(art);
        }

        public IActionResult AllArts()
        {
            IEnumerable<ArtDto> artDtos = _artClient.GetAllArtsAsync().Result;
            foreach (var art in artDtos)
            {
                art.ArtistName = GetAuthorName(art);
                art.Img64 = GetImageSourceFromByteArray(art.Image);

            }

            return View(artDtos);
        }
        public IActionResult AddtoCart(int id)
        {
            string isAuthenticated = _httpContextAccessor.HttpContext.Session.GetString("isAuthenticated");
            if (isAuthenticated.Equals("true"))
            {
                ArtDto art = _artClient.GetArtByIDAsync(id).Result;

                art.Img64 = GetImageSourceFromByteArray(art.Image);
                art.ArtistName = GetAuthorName(art);
                OrderLineItemDto orderLineItem = new OrderLineItemDto() { Art = art, Quantity = 1 };
                if (!CheckIfArtIsAlreadyInserted(art.Id))
                {
                    _orderDto.OrderLineItems.Add(orderLineItem);
                }
                else
                {
                    IncrementInsertedItemQuantity(art.Id);
                }
                _httpContextAccessor.HttpContext.Session.SaveShoppingCartInSession("cart", _orderDto);
                return Redirect(Request.Headers["Referer"].ToString());
            }
            else
            {
                return RedirectToAction("Login", "Accounts");
            }
            
        } 

        public string GetImageSourceFromByteArray(byte[] imgBytes)
        {
            string imreBase64Data = Convert.ToBase64String(imgBytes);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            return imgDataURL;
        }
        public string GetAuthorName(ArtDto art)
        {
            var artist = _personClient.GetPersonByIdAsync(art.AuthorId).Result;
            return (artist.FirstName + " " + artist.LastName);
        }
        public void InitializeShoppingCartAndSaveInSession()
        {
            if (_httpContextAccessor.HttpContext.Session.GetShoppingCartFromSession("cart") != null)
            {
                _orderDto = _httpContextAccessor.HttpContext.Session.GetShoppingCartFromSession("cart");
            }
            else
            {
                _orderDto = new OrderDto();
                _orderDto.OrderLineItems = new List<OrderLineItemDto>();
                _httpContextAccessor.HttpContext.Session.SaveShoppingCartInSession("cart", _orderDto);
            }
            if (_orderDto.OrderLineItems == null)
            {
                _orderDto.OrderLineItems = new List<OrderLineItemDto>();
            }
        }
        public bool CheckIfArtIsAlreadyInserted(int artId)
        {
            bool result = false;

            if (_orderDto.OrderLineItems.Any(item => item.Art.Id == artId)) {
                result = true;
            }
            return result;
        }
        public void IncrementInsertedItemQuantity(int artId)
        {
            var orderLineItem = _orderDto.OrderLineItems.Single(item => item.Art.Id == artId);
            if (orderLineItem != null && orderLineItem.Quantity < orderLineItem.Art.AvailableQuantity)
            {
            orderLineItem.Quantity++;
            }
        }
    }
}

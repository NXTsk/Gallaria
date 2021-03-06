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
            string isAuthenticated = _httpContextAccessor.HttpContext.Session.GetString("isAuthenticated");

            if (isAuthenticated.Equals("true"))
            {
                HttpContext.Session.SetString("isAuthenticated", "true");
            }
            else
            {
                HttpContext.Session.SetString("isAuthenticated", "false");
            }

            ArtDto art = _artClient.GetArtByIDAsync(id).Result;
            var artist = _personClient.GetPersonByIdAsync(art.AuthorId).Result;

            art.ArtistName = artist.FirstName + " " + artist.LastName;

            //Converting from basestring64 to image
            art.Img64 = ArtHelper.GetImageSourceFromByteArray(art.Image);

            return View(art);
        }

        public async Task<IActionResult> AllArts()
        {
            string isAuthenticated = _httpContextAccessor.HttpContext.Session.GetString("isAuthenticated");

            if (isAuthenticated.Equals("true"))
            {
                HttpContext.Session.SetString("isAuthenticated", "true");
            }
            else
            {
                HttpContext.Session.SetString("isAuthenticated", "false");
            }

            IEnumerable<ArtDto> artDtos = await _artClient.GetAllAvailableArtsAsync();
            foreach (var art in artDtos)
            {
                art.ArtistName = ArtHelper.GetAuthorName(art, _personClient);
                art.Img64 = ArtHelper.GetImageSourceFromByteArray(art.Image);
            }

            return View(artDtos);
        }

        public IActionResult AddtoCart(int id)
        {
            string isAuthenticated = _httpContextAccessor.HttpContext.Session.GetString("isAuthenticated");
            if (isAuthenticated.Equals("true"))
            {
                ArtDto art = _artClient.GetArtByIDAsync(id).Result;

                art.Img64 = ArtHelper.GetImageSourceFromByteArray(art.Image);
                art.ArtistName = ArtHelper.GetAuthorName(art, _personClient);
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

                return Redirect(Request.Headers["Referer"].ToString()); ;
            }
            else
            {
                return RedirectToAction("Login", "Accounts");
            }
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

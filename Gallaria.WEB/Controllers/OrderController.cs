using Gallaria.ApiClient.DTOs;
using Gallaria.ApiClient.Interfaces;
using Gallaria.WEB.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallaria.WEB.Controllers
{
    public class OrderController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IOrderClient _orderClient;

        public  OrderController(IHttpContextAccessor httpContextAccessor, IOrderClient orderClient) {

            _httpContextAccessor = httpContextAccessor;
            _orderClient = orderClient;
        }
        public IActionResult ShoppingCart()
        {
            OrderDto orderDto = _httpContextAccessor.HttpContext.Session.GetShoppingCartFromSession("cart");
            return View(orderDto);
        }
    }
}

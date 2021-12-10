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
        private IPersonClient _personClient;

        public  OrderController(IHttpContextAccessor httpContextAccessor, IOrderClient orderClient, IPersonClient personClient) {

            _httpContextAccessor = httpContextAccessor;
            _orderClient = orderClient;
            _personClient = personClient;

            //TODO: Use this when calling CreateOrder on OrderClient
            //CookieHelper.ReadJWT("X-Access-Token", _httpContextAccessor)
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            _httpContextAccessor.HttpContext.Session.Remove("wasOrderCompleted");
            OrderDto order = _httpContextAccessor.HttpContext.Session.GetShoppingCartFromSession("cart");
            order.Date = DateTime.Now;
            HttpContext.Request.Cookies.TryGetValue("userId", out string idString);
            int.TryParse(idString, out int id);
            order.Person = await _personClient.GetPersonByIdAsync(id);
            if (order != null && order.OrderLineItems!=null)
            {
                try
                {
                    int result = await _orderClient.CreateOrderAsync(order, CookieHelper.ReadJWT("X-Access-Token", _httpContextAccessor));
                    if (result != -1)
                    {
                        HttpContext.Session.Remove("cart");
                        _httpContextAccessor.HttpContext.Session.SetString("wasOrderCompleted", "true");

                        //TODO: Redirect to completed Order page
                        return RedirectToAction("AllArts", "Art");

                    }
                    else
                    {
                        _httpContextAccessor.HttpContext.Session.SetString("wasOrderCompleted", "false");
                        HttpContext.Session.Remove("cart");
                        return RedirectToAction("ShoppingCart", "Order");
                    }
                }
                catch (Exception)
                {
                    _httpContextAccessor.HttpContext.Session.SetString("wasOrderCompleted", "false");
                    return RedirectToAction("ShoppingCart", "Order");
                }
            }
            else
            {
                _httpContextAccessor.HttpContext.Session.SetString("wasOrderCompleted", "false");
                return RedirectToAction("ShoppingCart", "Order");
            }
        }

        public async Task<IActionResult> ShoppingCart()
        {
            OrderDto orderDto = _httpContextAccessor.HttpContext.Session.GetShoppingCartFromSession("cart");
            orderDto.FinalPrice = 0;
            if (orderDto.OrderLineItems != null)
            {
                foreach (OrderLineItemDto item in orderDto.OrderLineItems)
                {
                    orderDto.FinalPrice += item.Art.Price * item.Quantity;
                }
                _httpContextAccessor.HttpContext.Session.SaveShoppingCartInSession("cart", orderDto);
            }
            return View(orderDto);
        }
        public IActionResult RemoveItemFromShoppingCart(int id)
        {
            OrderDto orderDto = _httpContextAccessor.HttpContext.Session.GetShoppingCartFromSession("cart");
            var item = orderDto.OrderLineItems.Single(x => x.Art.Id == id);
            orderDto.OrderLineItems.Remove(item);
            orderDto.FinalPrice -= item.Art.Price * item.Quantity;
            _httpContextAccessor.HttpContext.Session.SaveShoppingCartInSession("cart", orderDto);
            return RedirectToAction("ShoppingCart");
        }

        public IActionResult IncrementQuantity(int id)
        {
            OrderDto orderDto = _httpContextAccessor.HttpContext.Session.GetShoppingCartFromSession("cart");
            var item = orderDto.OrderLineItems.Single(x => x.Art.Id == id);
            if (item.Quantity < item.Art.AvailableQuantity)
            {
            item.Quantity ++;
            _httpContextAccessor.HttpContext.Session.SaveShoppingCartInSession("cart", orderDto);
            }
            return RedirectToAction("ShoppingCart");
        }
        public IActionResult DecrementQuantity(int id)
        {
            OrderDto orderDto = _httpContextAccessor.HttpContext.Session.GetShoppingCartFromSession("cart");
            var item = orderDto.OrderLineItems.Single(x => x.Art.Id == id);
            if (item.Quantity > 1)
            {
                item.Quantity--;
                _httpContextAccessor.HttpContext.Session.SaveShoppingCartInSession("cart", orderDto);
            }
            return RedirectToAction("ShoppingCart");
        }



    }
}

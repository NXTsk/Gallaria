﻿using Gallaria.ApiClient.DTOs;
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
                        return RedirectToAction(nameof(CreateOrder), "Order");
                    }
                }
                catch (Exception)
                {
                    _httpContextAccessor.HttpContext.Session.SetString("wasOrderCompleted", "false");
                    return RedirectToAction(nameof(CreateOrder), "Order");
                }
            }
            else
            {
                _httpContextAccessor.HttpContext.Session.SetString("wasOrderCompleted", "false");
                return RedirectToAction(nameof(CreateOrder), "Order");
            }
        }

        public async Task<IActionResult> ShoppingCart()
        {
            OrderDto orderDto = _httpContextAccessor.HttpContext.Session.GetShoppingCartFromSession("cart");
            orderDto.Date = DateTime.Now;
            
            if (orderDto.OrderLineItems != null)
            {
                foreach (OrderLineItemDto item in orderDto.OrderLineItems)
                {
                    orderDto.FinalPrice += item.Art.Price * item.Quantity;
                }
            }
            return View(orderDto);
        }
        public IActionResult RemoveItemFromShoppingCart(int id)
        {
            OrderDto orderDto = _httpContextAccessor.HttpContext.Session.GetShoppingCartFromSession("cart");
            var item = orderDto.OrderLineItems.Single(x => x.Art.Id == id);
            orderDto.OrderLineItems.Remove(item);
            _httpContextAccessor.HttpContext.Session.SaveShoppingCartInSession("cart", orderDto);
            return RedirectToAction("ShoppingCart");
        }



    }
}

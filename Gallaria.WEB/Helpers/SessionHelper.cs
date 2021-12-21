using Gallaria.ApiClient.DTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallaria.WEB.Helpers
{
    public static class SessionHelper
    {

        public static void SaveShoppingCartInSession(this ISession session, string key, OrderDto order)
        {
            session.SetString(key, JsonConvert.SerializeObject(order));
            string s = session.GetString("cart");
        }

        public static OrderDto GetShoppingCartFromSession(this ISession session, string key)
        {
            OrderDto order = new OrderDto();
            var value = session.GetString(key);
            if (value != null)
            {
                order = JsonConvert.DeserializeObject<OrderDto>(value);
            }
            return order;
        }
    }
}

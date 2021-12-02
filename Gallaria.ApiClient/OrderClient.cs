//using Gallaria.ApiClient.DTOs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace Gallaria.ApiClient
//{
//    class OrderClient
//    {
//        private const string ApiUrl = "https://localhost:44327/";

//        public static async Task<OrderDto> CreateOrderAsync(OrderDto order)
//        {
//            var httpClient = new HttpClient();
//            bool returnValue = false;
//            OrderDto createdOrder = new OrderDto();
//            StringContent content = new StringContent(JsonConvert.SerializeObject(order), Encoding.Default, "application/json");

//            var response = await httpClient.PostAsync(ApiUrl + "api/art", content);
//            if (response.IsSuccessStatusCode)
//            {
//                string apiResponse = await response.Content.ReadAsStringAsync();
//                int createdResult = JsonConvert.DeserializeObject<int>(apiResponse);

//                returnValue = true;
//                createdOrder.Id = createdResult;
//            }

//            createdOrder.hasBeenCreated = returnValue;
//            return createdOrder;
//        }
//    }
//}

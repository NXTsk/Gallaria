using Gallaria.ApiClient.DTOs;
using Gallaria.ApiClient.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient
{
    public class OrderClient : IOrderClient
    {
        public string APIUrl { get; set; }
        public HttpClient HttpClient { get; set; }
        public OrderClient(string _APIUrl)
        {
            APIUrl = _APIUrl;
            HttpClient = new HttpClient();
        }

        public async Task<int> CreateOrderAsync(OrderDto order, string token)
        {

            StringContent content = new StringContent(JsonConvert.SerializeObject(order), Encoding.Default, "application/json");
            int returnValue = -1;

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await HttpClient.PostAsync(APIUrl + "api/Order", content);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                returnValue = JsonConvert.DeserializeObject<int>(apiResponse);
                HttpClient.DefaultRequestHeaders.Authorization = null;
            }

            return returnValue;
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            OrderDto order = new OrderDto();

            //HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await HttpClient.GetAsync(APIUrl + "api/Order/" + id);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                order = JsonConvert.DeserializeObject<OrderDto>(apiResponse);

                //resetting the RequestHeader
                //HttpClient.DefaultRequestHeaders.Authorization = null;
            }

            return order;
        }
    }
}

using Gallaria.ApiClient.DTOs;
using Gallaria.ApiClient.Helpers;
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

            int returnValue = -1;
            StringContent content = new StringContent(JsonConvert.SerializeObject(order), Encoding.Default, "application/json");

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

        public async Task<OrderDto> GetOrderByIdAsync(int id, string token)
        {
            OrderDto order = new OrderDto();

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await HttpClient.GetAsync(APIUrl + "api/Order/" + id);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                order = JsonConvert.DeserializeObject<OrderDto>(apiResponse);

                HttpClient.DefaultRequestHeaders.Authorization = null;
            }

            return order;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersByPersonIdAsync(int personId, string token)
        {
            IEnumerable<OrderDto> orderDtos = null;
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await HttpClient.GetAsync(APIUrl + "api/Order/getOrdersByPerson/" + personId);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                orderDtos = JsonConvert.DeserializeObject<IEnumerable<OrderDto>>(apiResponse);
                HttpClient.DefaultRequestHeaders.Authorization = null;
            }
            else
            {
                throw new Exception("Error retrieving all arts that belong to specific artist");
            }
            return orderDtos;
        }

        public async Task<bool> DeleteOrderAsync(int id, string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await HttpClient.DeleteAsync(APIUrl + "api/Order/" + id);

            if (response.IsSuccessStatusCode)
            {
                HttpClient.DefaultRequestHeaders.Authorization = null;
                return true;
            }
    
            return false;
        }
    }
}

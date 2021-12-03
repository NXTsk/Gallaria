using Gallaria.ApiClient.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient.Interfaces
{
    public class OrderLineItemClient : IOrderLineItemClient
    {
        public string APIUrl { get; set; }
        public HttpClient HttpClient { get; set; }

        public OrderLineItemClient(string _APIUrl)
        {
            APIUrl = _APIUrl;
            HttpClient = new HttpClient();
        }

        public async Task<int> CreateOrderLineItemAsync(OrderLineItemDto orderLineItem)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(orderLineItem), Encoding.Default, "application/json");
            int returnValue = -1;

            var response = await HttpClient.PostAsync(APIUrl + "api/OrderLineItem", content);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                returnValue = JsonConvert.DeserializeObject<int>(apiResponse);
            }

            return returnValue;
        }

        public async Task<bool> DeleteOrderLineItemAsync(int id)
        {
            bool returnValue = false;

            var response = await HttpClient.DeleteAsync(APIUrl + "api/OrderLineItem/" + id);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                returnValue = JsonConvert.DeserializeObject<bool>(apiResponse);
            }

            return returnValue;
        }

        public async Task<IEnumerable<OrderLineItemDto>> GetAllOrderLineItemsInOrderAsync(int id)
        {
            IEnumerable<OrderLineItemDto> orderLineItemDtos = null;

            //HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await HttpClient.GetAsync(APIUrl + "api/OrderLineItem/" + id);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                orderLineItemDtos = JsonConvert.DeserializeObject<IEnumerable<OrderLineItemDto>>(apiResponse);

                //resetting the RequestHeader
                //HttpClient.DefaultRequestHeaders.Authorization = null;
            }

            return orderLineItemDtos;
        }

        public async Task<OrderLineItemDto> GetOrderLineItemByIdAsync(int id)
        {
            OrderLineItemDto orderLineItem = new OrderLineItemDto();

            //HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await HttpClient.GetAsync(APIUrl + "api/OrderLineItem?Id=" + id);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                orderLineItem = JsonConvert.DeserializeObject<OrderLineItemDto>(apiResponse);

                //resetting the RequestHeader
                //HttpClient.DefaultRequestHeaders.Authorization = null;
            }

            return orderLineItem;
        }
    }
}

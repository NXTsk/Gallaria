using Gallaria.ApiClient.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient.Interfaces
{
    public interface IOrderLineItemClient
    {
        public string APIUrl { get; set; }
        public HttpClient HttpClient { get; set; }

        public Task<int> CreateOrderLineItemAsync(OrderLineItemDto orderLineItem);
        public Task<bool> DeleteOrderLineItemAsync(int id);
        public Task<IEnumerable<OrderLineItemDto>> GetAllOrderLineItemsInOrderAsync(int id);
        public Task<OrderLineItemDto> GetOrderLineItemByIdAsync(int id);
    }
}

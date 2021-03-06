using Gallaria.ApiClient.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient.Interfaces
{
    public interface IOrderClient
    {
        public string APIUrl { get; set; }
        public HttpClient HttpClient { get; set; }

        public Task<int> CreateOrderAsync(OrderDto order, string token);
        public Task<OrderDto> GetOrderByIdAsync(int id, string token);
        public Task<IEnumerable<OrderDto>> GetAllOrdersByPersonIdAsync(int personId, string token);
        public Task<bool> DeleteOrderAsync(int id, string token);
    }
}

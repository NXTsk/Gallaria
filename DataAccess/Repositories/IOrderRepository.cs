using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IOrderRepository
    {
        // OrderRepository
        Task<int> CreateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int id);
        Task<Order> GetOrderByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        //OrderLineItemRepository
        //Task<int> CreateOrderLineItemAsync(OrderLineItem orderLineItem, int orderId);
        Task<bool> DeleteOrderLineItemAsync(int id);
        Task<OrderLineItem> GetOrderLineItemByIdAsync(int id);
        Task<ICollection<OrderLineItem>> GetAllOrderLineItemsInOrderAsync(int id);
    }
}

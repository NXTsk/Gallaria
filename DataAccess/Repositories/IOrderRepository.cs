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
        Task<IEnumerable<Order>> GetAllOrdersByPersonIdAsync(int personId);

        //OrderLineItemRepository
        Task<bool> DeleteOrderLineItemAsync(int id);
        Task<OrderLineItem> GetOrderLineItemByIdAsync(int id);
        Task<ICollection<OrderLineItem>> GetAllOrderLineItemsInOrderAsync(int id);
    }
}

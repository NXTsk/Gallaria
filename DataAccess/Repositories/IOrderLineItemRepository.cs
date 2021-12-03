using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IOrderLineItemRepository
    {
        Task<int> CreateOrderLineItemAsync(OrderLineItem orderLineItem);
        Task<bool> DeleteOrderLineItemAsync(int id);
        Task<OrderLineItem> GetOrderLineItemByIdAsync(int id);
        Task<IEnumerable<OrderLineItem>> GetAllOrderLineItemsInOrderAsync(int id);
    }
}

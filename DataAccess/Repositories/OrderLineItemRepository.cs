using Dapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderLineItemRepository : BaseRepository, IOrderLineItemRepository
    {
        public OrderLineItemRepository(string connectionstring) : base(connectionstring) { }

        public async Task<int> CreateOrderLineItemAsync(OrderLineItem orderLineItem)
        {
            try
            {
                var query = "INSERT INTO OrderLineItem (OrderId, ArtId, Quantity)" +
                    "OUTPUT INSERTED.Id VALUES (@OrderId, @ArtId, @Quantity);";
                using var connection = CreateConnection();
                return await connection.QuerySingleAsync<int>(query, new
                {
                    OrderId = orderLineItem.OrderId,
                    ArtId = orderLineItem.Art.Id,
                    Quantity = orderLineItem.Quantity
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating new Order: '{ex.Message}'.", ex);
            }
        }

        public async Task<bool> DeleteOrderLineItemAsync(int id)
        {
            try
            {
                var query = "DELETE FROM OrderLineItem WHERE Id=@Id";
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, new { id }) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting orderLineItem with id {id}: '{ex.Message}'.", ex);
            }
        }

        public async Task<IEnumerable<OrderLineItem>> GetAllOrderLineItemsInOrderAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM OrderLineItem WHERE orderId=@Id";
                using var connection = CreateConnection();
                return (await connection.QueryAsync<OrderLineItem>(query, id)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all orderLineItems in specific order: '{ex.Message}'.", ex);
            }
        }

        public async Task<OrderLineItem> GetOrderLineItemByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM OrderLineItem WHERE Id=@Id";
                using var connection = CreateConnection();
                return await connection.QuerySingleAsync<OrderLineItem>(query, new { id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting orderLineItem with id {id}: '{ex.Message}'.", ex);
            }
        }
    }
}

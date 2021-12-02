using Dapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(string connectionstring) : base(connectionstring) { }
   
        public async Task<int> CreateOrderAsync(Order order)
        {
            try
            {
                var query = "INSERT INTO Order (Date, FinalPrice)" +
                    " OUTPUT INSERTED.Id VALUES (@Date, @FinalPrice);";
                using var connection = CreateConnection();
                return await connection.QuerySingleAsync<int>(query, new
                {
                    Date = order.Date,
                    FinalPrice = order.FinalPrice,
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating new Order: '{ex.Message}'.", ex);
            }
        }

    public async Task<bool> DeleteOrderAsync(int id)
    {
        try
        {
            var query = "DELETE FROM Order WHERE Id=@Id";
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(query, new { id }) > 0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting order with id {id}: '{ex.Message}'.", ex);
        }
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        try
        {
            var query = "SELECT * FROM Order";
            using var connection = CreateConnection();
            return (await connection.QueryAsync<Order>(query)).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting all orders: '{ex.Message}'.", ex);
        }
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        try
        {
            var query = "SELECT * FROM Order WHERE Id=@Id";
            using var connection = CreateConnection();
            return await connection.QuerySingleAsync<Order>(query, new { id });
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting order with id {id}: '{ex.Message}'.", ex);
        }
    }
}
}

using Dapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        private OrderRepository _orderRepository;

        public OrderRepository(string connectionstring) : base(connectionstring) { }


        public int CreateOrder(Order order)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    connection.Open();

                    //Begin the transaction
                    using (var transaction = connection.BeginTransaction())
                    {
                        string sqlStringOrder = "INSERT INTO dbo.[Order](PersonId, Date, FinalPrice) VALUES (@PersonId, @Date, @FinalPrice);" +
                        "SELECT CAST(SCOPE_IDENTITY() as int)";

                        string sqlStringOrderLineItem = "INSERT INTO dbo.[OrderLineItem](OrderId, ArtId, Quantity) VALUES (@OrderId, @ArtId, @Quantity);" +
                        "SELECT CAST(SCOPE_IDENTITY() as int)";

                        var orderDetails = new { PersonId = order.Person.Id, Date = order.Date, FinalPrice = order.FinalPrice };
                        int orderId = connection.QuerySingle<int>(sqlStringOrder, orderDetails, transaction: transaction);

                        foreach (OrderLineItem item in order.OrderLineItems)
                        {
                            //Insert record in detail table. Pass transaction parameter to Dapper.
                            var orderLineDetails = new { OrderId = orderId, ArtId = item.Art.Id, Quantity = item.Quantity };
                            int orderLineItemId = connection.QuerySingle<int>(sqlStringOrderLineItem, orderLineDetails, transaction: transaction);
                        }

                        //Commit transaction
                        transaction.Commit();
                        return orderId;
                    }
                }
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
                var query = "DELETE FROM dbo.[Order] WHERE Id=@Id";
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

        //public async Task<int> CreateOrderLineItemAsync(OrderLineItem orderLineItem, int orderId)
        //{
        //    try
        //    {
        //        var query = "INSERT INTO OrderLineItem (OrderId, ArtId, Quantity)" +
        //            "OUTPUT INSERTED.Id VALUES (@OrderId, @ArtId, @Quantity);";
        //        using var connection = CreateConnection();
        //        return await connection.QuerySingleAsync<int>(query, new
        //        {
        //            OrderId = orderId,
        //            ArtId = orderLineItem.Art.Id,
        //            Quantity = orderLineItem.Quantity
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Error creating new Order: '{ex.Message}'.", ex);
        //    }
        //}

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

        public async Task<ICollection<OrderLineItem>> GetAllOrderLineItemsInOrderAsync(int id)
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

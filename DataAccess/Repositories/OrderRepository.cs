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
        private IArtRepository _artRepository;
        public OrderRepository(string connectionstring) : base(connectionstring) 
        {
            _artRepository = new ArtRepository(connectionstring);
        }


        public async Task<int> CreateOrderAsync(Order order)
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
                        try
                        {
                            int orderId = connection.QuerySingle<int>(sqlStringOrder, orderDetails, transaction: transaction);

                            bool canCommit = true;

                            foreach (OrderLineItem item in order.OrderLineItems)
                            {
                                //Insert record in detail table. Pass transaction parameter to Dapper.
                                var orderLineDetails = new { OrderId = orderId, ArtId = item.Art.Id, Quantity = item.Quantity };
                                int orderLineItemId = connection.QuerySingle<int>(sqlStringOrderLineItem, orderLineDetails, transaction: transaction);
                                Art art = await _artRepository.GetArtByIDAsync(item.Art.Id);
                                
                                if (art.AvailableQuantity < item.Quantity)
                                {
                                    canCommit = false;
                                }
                                else
                                {
                                    await _artRepository.UpdateArtQuantityById(art.Id, art.AvailableQuantity - item.Quantity);
                                }
                            }
                            if (canCommit)
                            {
                                //Commit transaction
                                transaction.Commit();
                                return orderId;
                            }
                            else
                            {
                                transaction.Rollback();
                                return -1;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                            Console.WriteLine("  Message: {0}", ex.Message);
                            // Attempt to roll back the transaction.
                            try
                            {
                                transaction.Rollback();
                                return -1;
                            }
                            catch (Exception ex2)
                            {
                                // This catch block will handle any errors that may have occurred
                                // on the server that would cause the rollback to fail, such as
                                // a closed connection.
                                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                                Console.WriteLine("  Message: {0}", ex2.Message);
                                throw new Exception(ex2.Message);
                            }
                        }
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
                var query = "SELECT * FROM dbo.[Order]";
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
                var query = "SELECT * FROM dbo.[Order] WHERE Id=@Id";
                using var connection = CreateConnection();
                return await connection.QuerySingleAsync<Order>(query, new { id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting order with id {id}: '{ex.Message}'.", ex);
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

        public async Task<ICollection<OrderLineItem>> GetAllOrderLineItemsInOrderAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM OrderLineItem WHERE orderId=@Id";
                using var connection = CreateConnection();
                return (await connection.QueryAsync<OrderLineItem>(query, new { id })).ToList();
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

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
                        string sqlString = "INSERT INTO Order (PersonId, Date, FinalPrice)" +
                        " OUTPUT INSERTED.Id VALUES (@PersonId, @Date, @FinalPrice);";

                        //Create and fill-up master table data
                        //var paramMaster = new DynamicParameters();
                        //paramMaster.Add("@PersonId", order.Person.Id);
                        //paramMaster.Add("@Date", order.Date);
                        //paramMaster.Add("@FinalPrice", order.FinalPrice);

                        //Insert record in master table. Pass transaction parameter to Dapper.
                        var affectedRowsOrder = connection.QuerySingleAsync<int>(sqlString, new {PersonId = order.Person.Id, Date = order.Date, FinalPrice = order.FinalPrice}, transaction: transaction);

                        //Get the Id newly created for master table record.
                        //If this is not an Identity, use different method here
                        int orderId;
                        orderId = await connection.ExecuteScalarAsync<int>("SELECT @@IDENTITY", null, transaction: transaction);

                        //Create and fill-up detail table data
                        //Use suitable loop as you want to insert multiple records.
                        //for(......)
                        foreach (OrderLineItem item in order.OrderLineItems)
                        {
                            var paramDetails = new DynamicParameters();
                            paramDetails.Add("@OrderId", orderId);
                            paramDetails.Add("@ArtId", item.Art.Id);
                            paramDetails.Add("@Quantity", item.Quantity);

                            //Insert record in detail table. Pass transaction parameter to Dapper.
                            var affectedRowsOrderLineItem = connection.QuerySingleAsync<int>("INSERT INTO OrderLineItem (OrderId, ArtId, Quantity)" +
                            "OUTPUT INSERTED.Id VALUES (@OrderId, @ArtId, @Quantity);", paramDetails, transaction: transaction);
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

        //    try
        //    {
        //        var query = "INSERT INTO Order (personId, date, finalPrice)" +
        //            " OUTPUT INSERTED.Id VALUES (@PersonId, @Date, @FinalPrice);";
        //        using var connection = CreateConnection();
        //        int orderId = await connection.QuerySingleAsync<int>(query, new
        //        {
        //            PersonId = order.Person.Id,
        //            Date = order.Date,
        //            FinalPrice = order.FinalPrice
        //        });

        //        foreach (OrderLineItem orderLineItem in order.OrderLineItems)
        //        {
        //            await _orderRepository.CreateOrderLineItemAsync(orderLineItem, orderId);
        //        }

        //        return orderId;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Error creating new Order: '{ex.Message}'.", ex);
        //    }
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

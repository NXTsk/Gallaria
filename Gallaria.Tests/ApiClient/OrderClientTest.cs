using Gallaria.ApiClient;
using Gallaria.ApiClient.DTOs;
using Gallaria.ApiClient.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.Tests.ApiClient
{
    class OrderClientTest
    {
        private IOrderClient _orderClient;

        private List<OrderLineItemDto> orderLineItemDtos;

        private PersonDto person;
        private List<OrderLineItemDto> orderLineItems;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //TODO: Create a personDTO for the order
            _orderClient = new OrderClient(Configuration.API_URL);

            person = new()
            {
                Id = 1
            };

            orderLineItems = new List<OrderLineItemDto>
            {
                new OrderLineItemDto {
                    Art = new ArtDto{
                        
                    },

                },
                new OrderLineItemDto {}
            };
        }

        [Test]
        public async Task TestCreateOrder()
        {
            //TODO: Arrange
            OrderDto orderDto = new() {
                Date = DateTime.Now,
                FinalPrice = 150,
                Person = person,
                OrderLineItems = orderLineItems
            };  

            //Act
            int actualId = await _orderClient.CreateOrderAsync(orderDto);

            //Assert
            Assert.IsTrue(actualId > 0, $"Failed to create an order for: {orderDto.Person.FirstName} {orderDto.Person.LastName}!");
        }

        [Test]
        public async Task TestGetOrderByIdAsync()
        {
            //Arrange
            int id = 15;
            //Act
            OrderDto orderDto = await _orderClient.GetOrderByIdAsync(id);

            //TODO: Assert
            Assert.AreEqual(id, orderDto.Id, "Recieved order wasn't with id 1");
        }
    }
}

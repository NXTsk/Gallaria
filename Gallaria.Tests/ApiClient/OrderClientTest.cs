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
        private IArtClient _artClient;
        private IPersonClient _personClient;
        private IAuthenticateClient _authenticateClient;

        private List<OrderLineItemDto> orderLineItemDtos;

        private PersonDto person;
        private AuthUserDto authUser;
        private List<OrderLineItemDto> orderLineItems;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            //TODO: Create a personDTO for the order
            _orderClient = new OrderClient(Configuration.API_URL);
            _artClient = new ArtClient(Configuration.API_URL);
            _personClient = new PersonClient(Configuration.API_URL);
            _authenticateClient = new AuthenticateClient(Configuration.API_URL);

            authUser = await _authenticateClient.LoginAsync(new UserDto() {
                Email = "denisacreative@gmail.com",
                Password = "1234567"
            });

            person = await _personClient.GetPersonByIdAsync(152);
            orderLineItems = new List<OrderLineItemDto>
            {
                new OrderLineItemDto {
                    Art = await _artClient.GetArtByIDAsync(31),
                    Quantity = 1
                }
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
            int actualId = await _orderClient.CreateOrderAsync(orderDto, authUser.Token);

            //Assert
            Assert.IsTrue(actualId > 0, $"Failed to create an order for: {orderDto.Person.FirstName} {orderDto.Person.LastName}!");
        }

        [Test]
        public async Task TestGetOrderByIdAsync()
        {
            //Arrange
            int id = 207;
            //Act
            OrderDto orderDto = await _orderClient.GetOrderByIdAsync(id);

            //TODO: Assert
            Assert.AreEqual(id, orderDto.Id, "Recieved order wasn't with id 1");
        }
    }
}

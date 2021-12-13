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

        private ArtistDto artist;
        private ArtDto art;
        private AuthUserDto authUser;
        private List<OrderLineItemDto> orderLineItems;
        private OrderDto orderToCreate;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _orderClient = new OrderClient(Configuration.API_URL);
            _artClient = new ArtClient(Configuration.API_URL);
            _personClient = new PersonClient(Configuration.API_URL);
            _authenticateClient = new AuthenticateClient(Configuration.API_URL);

            await CreateArtistAsync();
            await CreateArtAsync();

            authUser = await _authenticateClient.LoginAsync(new UserDto()
            {
                Email = artist.Email,
                Password = artist.HashPassword
            });

            orderLineItems = new List<OrderLineItemDto>
            {
                new OrderLineItemDto {
                    Art = art,
                    Quantity = 1
                }
            };

            await CreateOrderAsync();
        }

        public async Task CreateArtistAsync()
        {
            artist = new()
            {
                Email = "galantniadam@gmail.com",
                FirstName = "Adam",
                LastName = "Galantni",
                HashPassword = "123456789",
                PhoneNumber = "68598487",
                ProfileDescription = "I am the king in a west.",
                Address = new() { City = "Copenhagen", Country = "Denmark", HouseNumber = "154", Street = "Slotsgade", Zipcode = "84536" }
            };

            artist.Id = await _personClient.CreateArtistAsync(artist);
        }

        public async Task CreateArtAsync()
        {
            art = new()
            {
                AuthorId = artist.Id,
                ArtistName = artist.FirstName,
                Title = "The best piece of art",
                Description = "This is most certainly the best piece of art you can ever see.",
                AvailableQuantity = 1,
                Category = "Anime",
                CreationDate = DateTime.Now,
                Price = 20000,
                Image = System.IO.File.ReadAllBytes("../../../testImages/11.jpg")
            };
            art.Id = await _artClient.CreateArtAsync(art);
        }

        public async Task CreateOrderAsync() 
        {
            orderToCreate = new()
            {
                Date = DateTime.Now,
                FinalPrice = 20000,
                Person = artist,
                OrderLineItems = orderLineItems
            };
            orderToCreate.Id = await _orderClient.CreateOrderAsync(orderToCreate, authUser.Token);
        }

        [Test]
        public async Task TestCreateOrder()
        {
            //Arrange & Act is done in OneTimeSetup()    
            //Assert
            Assert.IsTrue(orderToCreate.Id > 0, $"Failed to create an order for: {orderToCreate.Person.FirstName} {orderToCreate.Person.LastName}!");
        }

        [Test]
        public async Task TestGetOrderById()
        {
            //Arrange
            int id = orderToCreate.Id;

            //Act
            OrderDto orderDto = await _orderClient.GetOrderByIdAsync(id);

            //Assert
            Assert.AreEqual(id, orderDto.Id, "Recieved order wasn't equal");
        }

        [OneTimeTearDown]
        public async Task CleanUp()
        {
            await _orderClient.DeleteOrderAsync(orderToCreate.Id);
            await _artClient.DeleteArtAsync(art.Id);
            await _personClient.DeleteArtistAsync(artist.Id);
            await _personClient.DeletePersonAsync(artist.Id);
        }
    }
}

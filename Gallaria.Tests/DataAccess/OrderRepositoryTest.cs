using DataAccess.Model;
using DataAccess.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.Tests.DataAccess
{
    class OrderRepositryTest
    {
        private IOrderRepository _orderRepository;
        private IPersonRepository _personRepository;
        private IArtRepository _artRepository;
        private Person _newPerson;
        private string _password = "TestPassword";
        private Order _newOrder;
        private Art _newArt;
        private OrderLineItem _newOrderLineItem;

        [SetUp]
        public async Task Setup()
        {
            _orderRepository = new OrderRepository(Configuration.CONNECTION_STRING);
            _artRepository = new ArtRepository(Configuration.CONNECTION_STRING);
            _personRepository = new PersonRepository(Configuration.CONNECTION_STRING);

            await CreateNewPerson();
            await CreateNewArt();
            _newOrder = await CreateNewOrder();
        }

        private async Task<Person> CreateNewPerson()
        {
            Address a = new Address() { Street = "Dannebrogsgade", HouseNumber = "13", Zipcode = "9000", City = "Aalborg", Country = "Denmark" };
            _newPerson = new Person() { FirstName = "Laco", LastName = "Cobolski", Email = "laco@slovak.sk", PhoneNumber = "123456", Address = a };
            _newPerson.Id = await _personRepository.CreatePersonAsync(_newPerson, _password);
            return _newPerson;
        }

        
        private OrderLineItem CreateNewOrderLineItem()
        {
            _newOrderLineItem = new OrderLineItem() {Art = _newArt, Quantity = 5 };

            return _newOrderLineItem;
        }

        private async Task<Art> CreateNewArt()
        {
            byte[] bytes = System.IO.File.ReadAllBytes("../../../testImages/11.jpg");
            _newArt = new Art() { AuthorId = 152, Title = "New art", Description = "hello", Image = bytes, Price = 10, AvailableQuantity = 20, Category = "Nature", CreationDate = new DateTime(2021, 11, 20) };
            _newArt.Id = await _artRepository.CreateArtAsync(_newArt);

            return _newArt;
        }

        private async Task<Order> CreateNewOrder()
        {
            List<OrderLineItem> _newOrderLineItems = new List<OrderLineItem>();

            _newOrder = new Order() {Date = DateTime.Now, FinalPrice = 50, Person = _newPerson, OrderLineItems = _newOrderLineItems};
            _newOrder.OrderLineItems.Add(CreateNewOrderLineItem());
            _newOrder.Id = await _orderRepository.CreateOrderAsync(_newOrder);

            return _newOrder;
        }

        [Test]
        public void CreateOrder()
        {
            //arrange & act is done in setup()
            //assert
            Assert.IsTrue(_newOrder.Id > 0, "order was not created");
        }


        [TearDown]
        public async Task CleanUp()
        {
            //await _orderRepository.DeleteOrderAsync(_newOrder.Id);
            //await _orderRepository.DeleteOrderLineItemAsync(_newOrderLineItem.Id);
            await _personRepository.DeleteArtistAsync(_newPerson.Id);
            await _artRepository.DeleteArtAsync(_newArt.Id);
        }
    }
}

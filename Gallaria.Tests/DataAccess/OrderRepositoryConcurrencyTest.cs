using DataAccess.Model;
using DataAccess.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.Tests.DataAccess
{
    class OrderRepositoryConcurrencyTest
    {
        private IOrderRepository _orderRepository;
        private IPersonRepository _personRepository;
        private IArtRepository _artRepository;

        private Person _person1;
        private Person _person2;

        private Art _newArt;
        private OrderLineItem _newOrderLineItem;

        private Order _order1;

        [SetUp]
        public async Task Setup()
        {
            _orderRepository = new OrderRepository(Configuration.CONNECTION_STRING);
            _artRepository = new ArtRepository(Configuration.CONNECTION_STRING);
            _personRepository = new PersonRepository(Configuration.CONNECTION_STRING);

            await CreatePerson1();
            await CreatePerson2();
            await CreateNewArt();
            CreateNewOrderLineItem();
        }

        [Test]
        public async Task ConcurrencyOrder() 
        {
            //Arrange
            //Act
            _order1 = await CreateNewOrder(_person1, _newOrderLineItem);
            Order order2 = await CreateNewOrder(_person2, _newOrderLineItem);

            //Assert
            Assert.IsTrue(_order1.Id > 0, "order was not created");
            Assert.IsTrue(order2.Id <= 0, "order was or wasn't created");
        }

        [TearDown]
        public async Task CleanUp()
        {
            await _orderRepository.DeleteOrderAsync(_order1.Id);
            await _personRepository.DeletePersonAsync(_person1.Id);
            await _personRepository.DeletePersonAsync(_person2.Id);
            await _artRepository.DeleteArtAsync(_newArt.Id);
        }

        #region Create Order
        private async Task<Order> CreateNewOrder(Person person, OrderLineItem item)
        {
            Order _newOrder;
            List<OrderLineItem> _newOrderLineItems = new List<OrderLineItem>();

            _newOrder = new Order() { Date = DateTime.Now, FinalPrice = 50, Person = person, OrderLineItems = _newOrderLineItems };
            _newOrder.OrderLineItems.Add(item);
            _newOrder.Id = await _orderRepository.CreateOrderAsync(_newOrder);

            return _newOrder;
        }
        #endregion

        #region Create people
        private async Task<Person> CreatePerson1()
        {
            Address a = new Address() { Street = "Dannebrogsgade", HouseNumber = "13", Zipcode = "9000", City = "Aalborg", Country = "Denmark" };
            _person1 = new Person() { FirstName = "Jacob", LastName = "Working", Email = "jacob@working.com", PhoneNumber = "50151412", Address = a };
            _person1.Id = await _personRepository.CreatePersonAsync(_person1, "123456");
            return _person1;
        }

        private async Task<Person> CreatePerson2()
        {
            Address a = new Address() { Street = "Dannebrogsgade", HouseNumber = "13", Zipcode = "9000", City = "Aalborg", Country = "Denmark" };
            _person2 = new Person() { FirstName = "Martin", LastName = "Working", Email = "martin@working.com", PhoneNumber = "50151412", Address = a };
            _person2.Id = await _personRepository.CreatePersonAsync(_person2, "123456");
            return _person2;
        }
        #endregion

        #region Create art and orderLineItem
        private async Task<Art> CreateNewArt()
        {
            byte[] bytes = System.IO.File.ReadAllBytes("../../../testImages/11.jpg");
            _newArt = new Art() { AuthorId = 152, Title = "Concurrency art", Description = "hello", Image = bytes, Price = 10, AvailableQuantity = 1, Category = "Nature", CreationDate = new DateTime(2021, 11, 20) };
            _newArt.Id = await _artRepository.CreateArtAsync(_newArt);

            return _newArt;
        }
        private OrderLineItem CreateNewOrderLineItem()
        {
            _newOrderLineItem = new OrderLineItem() { Art = _newArt, Quantity = 1 };

            return _newOrderLineItem;
        }
        #endregion
    }
}

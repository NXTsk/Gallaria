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
        private string _password = "123456";
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
            _newOrder = CreateNewOrder();
        }

        private async Task<Person> CreateNewPerson()
        {
            Address a = new Address() { Street = "Dannebrogsgade", HouseNumber = "13", Zipcode = "9000", City = "Aalborg", Country = "Denmark" };
            _newPerson = new Person() { FirstName = "Jacob", LastName = "Working", Email = "jacob@working.com", PhoneNumber = "50151412", Address = a };
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

        private Order CreateNewOrder()
        {
            List<OrderLineItem> _newOrderLineItems = new List<OrderLineItem>();

            _newOrder = new Order() {Date = DateTime.Now, FinalPrice = 50, Person = _newPerson, OrderLineItems = _newOrderLineItems};
            _newOrder.OrderLineItems.Add(CreateNewOrderLineItem());
            _newOrder.Id = _orderRepository.CreateOrder(_newOrder);

            return _newOrder;
        }

        [Test]
        public void CreateOrder()
        {
            //arrange & act is done in setup()
            //assert
            Assert.IsTrue(_newOrder.Id > 0, "order was not created");
        }

        [Test]
        public async Task GettingOrderBySpecificIdReturnOrder()
        {
            //Arragne
            //Act
            Order order = await _orderRepository.GetOrderByIdAsync(64);

            //Assert
            Assert.NotNull(order, "Order with ID 64 was not found");
            Assert.IsTrue(order.Id == 64, $"Actual ID of art was {order.Id} not 64");
        }

        [Test]
        public async Task GettingAllOrdersReturnsListOfOrders()
        {
            //Arrange
            //Act
            IEnumerable<Order> orders = await _orderRepository.GetAllOrdersAsync();

            //Assert
            Assert.NotNull(orders.Any(), "List of orders is 0");
        }

        [Test]
        public async Task DeleteOrder()
        {
            //Arrange is done in Setup()

            //Act 
            bool deleted = await _orderRepository.DeleteOrderAsync(_newOrder.Id);

            //Assert
            Assert.IsTrue(deleted, "Order was not deleted");
        }

        //[Test]
        //public void CreateOrderLineItem()
        //{
        //    //arrange & act is done in setup()
        //    //assert
        //    Assert.IsTrue(_newOrderLineItem.Id > 0, "orderLineItem was not created");
        //}

        [Test]
        public async Task GettingOrderLineItemBySpecificIdReturnOrderLineItem()
        {
            //Arragne
            //Act
            OrderLineItem orderLineItem = await _orderRepository.GetOrderLineItemByIdAsync(68);

            //Assert
            Assert.NotNull(orderLineItem, "Order with ID 68 was not found");
            Assert.IsTrue(orderLineItem.Id == 68, $"Actual ID of art was {orderLineItem.Id} not 68");
        }

        [Test]
        public async Task GettingAllOrderLineItemsReturnsListOfOrderLineItems()
        {
            //Arrange
            //Act
            IEnumerable<OrderLineItem> orderLineItems = await _orderRepository.GetAllOrderLineItemsInOrderAsync(64);

            //Assert
            Assert.NotNull(orderLineItems.Any(), "List of orders is 0");
        }

        [TearDown]
        public async Task CleanUp()
        {
            await _orderRepository.DeleteOrderAsync(_newOrder.Id);
            //await _orderRepository.DeleteOrderLineItemAsync(_newOrderLineItem.Id);
            await _personRepository.DeletePersonAsync(_newPerson.Id);
            await _artRepository.DeleteArtAsync(_newArt.Id);
        }
    }
}

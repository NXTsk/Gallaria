using DataAccess.Model;
using DataAccess.Repositories;
using Gallaria.API.Converters;
using Gallaria.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderLineItemController : Controller
    {
        IConfiguration _config;
        IOrderLineItemRepository _orderLineItemRepository;

        public OrderLineItemController(IConfiguration config)
        {
            _config = config;
            _orderLineItemRepository = new OrderLineItemRepository(_config["ConnectionStrings:MSSQLconnection"]);
        }

        // IDK IF THIS IS OKAY
        // POST api/person
        [HttpPost]
        public async Task<ActionResult<int>> CreateOrderLineItemAsync([FromBody] OrderLineItemDto newOrderLineItemDto, int orderId)
        {
            return Ok(await _orderLineItemRepository.CreateOrderLineItemAsync(newOrderLineItemDto.FromDto(), orderId));
        }

        // GET api/<OrderLineItemController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderLineItemDto>> GetAllOrderLineItemByIdAsync(int id)
        {
            var order = await _orderLineItemRepository.GetOrderLineItemByIdAsync(id);
            if (order == null) { return NotFound(); }
            else { return Ok(order); }
        }

        // DELETE api/<OrderLineItemController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteOrderLineItemAsync(int id)
        {
            if (!await _orderLineItemRepository.DeleteOrderLineItemAsync(id)) { return NotFound(); }
            else { return Ok(); }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderLineItemDto>>> GetAllOrderLineItemsInOrderAsync([FromQuery] int id)
        {
            IEnumerable<OrderLineItem> orderLineItems;

            orderLineItems = await _orderLineItemRepository.GetAllOrderLineItemsInOrderAsync(id);

            return Ok(orderLineItems.ToDtos());
        }
    }
}


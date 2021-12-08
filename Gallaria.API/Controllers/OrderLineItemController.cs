using DataAccess.Model;
using DataAccess.Repositories;
using Gallaria.API.Converters;
using Gallaria.API.DTOs;
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
        IOrderRepository _orderRepository;

        public OrderLineItemController(IConfiguration config)
        {
            _config = config;
            _orderRepository = new OrderRepository(_config["ConnectionStrings:MSSQLconnection"]);
        }

        // IDK IF THIS IS OKAY
        // POST api/person
        //[HttpPost]
        //public async Task<ActionResult<int>> CreateOrderLineItemAsync([FromBody] OrderLineItemDto newOrderLineItemDto)
        //{
        //    return Ok(await _orderRepository.CreateOrderLineItemAsync(newOrderLineItemDto.FromDto()));
        //}

        // GET api/<OrderLineItemController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderLineItemDto>> GetAllOrderLineItemByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderLineItemByIdAsync(id);
            if (order == null) { return NotFound(); }
            else { return Ok(order); }
        }

        // DELETE api/<OrderLineItemController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteOrderLineItemAsync(int id)
        {
            if (!await _orderRepository.DeleteOrderLineItemAsync(id)) { return NotFound(); }
            else { return Ok(); }
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<OrderLineItemDto>>> GetAllOrderLineItemsInOrderAsync([FromQuery] int id)
        {
            ICollection<OrderLineItem> orderLineItems;

            orderLineItems = await _orderRepository.GetAllOrderLineItemsInOrderAsync(id);

            return Ok(orderLineItems.ToDtos());
        }
    }
}


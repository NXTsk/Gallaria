using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Repositories;
using Gallaria.API.Converters;
using Gallaria.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Gallaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        IConfiguration _config;
        IOrderRepository _orderRepository;

        public OrderController(IConfiguration config)
        {
            _config = config;
            _orderRepository = new OrderRepository(_config["ConnectionStrings:MSSQLconnection"]);
        }

        // POST api/order
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> CreateOrderAsync([FromBody] OrderDto newOrderDto)
        {
            return Ok(await _orderRepository.CreateOrderAsync(newOrderDto.FromDto()));
        }

        // GET api/<OrderController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null) { return NotFound(); }
            else { return Ok(order); }
        }
    }
}

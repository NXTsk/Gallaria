﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallaria.API.Model
{
    public class OrderDto
    {
        public int Id { get; set; }
        public IEnumerable<OrderLineItemDto> OrderLineItems { get; set; }
        public PersonDto Person { get; set; }
        public DateTime Date { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
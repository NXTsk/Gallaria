using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallaria.API.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal FinalPrice { get; set; }
        public PersonDto Person { get; set; }
        public ICollection<OrderLineItemDto> OrderLineItems { get; set; }
    }
}

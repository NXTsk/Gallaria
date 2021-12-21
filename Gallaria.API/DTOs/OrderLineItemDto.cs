using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallaria.API.DTOs
{
    public class OrderLineItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public ArtDto Art { get; set; }
        public int Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallaria.API.Model
{
    public class OrderLineItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ArtDto Art { get; set; }
    }
}

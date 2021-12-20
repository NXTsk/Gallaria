using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class OrderLineItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Art Art { get; set; }

        public int ArtId { get; set; } 
        public int Quantity { get; set; }
    }
}

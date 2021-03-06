using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal FinalPrice { get; set; }
        public Person Person { get; set; }
        public ICollection<OrderLineItem> OrderLineItems { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient.DTOs
{
    class OrderLineItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public ArtDto Art { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }
    }
}

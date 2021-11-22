using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient.DTOs
{
    class ArtDto
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public byte[] Image { get; set; }

        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public string Category { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

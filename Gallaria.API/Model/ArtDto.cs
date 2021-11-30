using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallaria.API.Model
{
    public class ArtDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public string Category { get; set; }
        public DateTime CreationDate { get; set; }

    }
}

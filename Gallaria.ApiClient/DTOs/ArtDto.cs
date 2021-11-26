using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient.DTOs
{
    public class ArtDto
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public string Category { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreationDate { get; set; }
    }
}

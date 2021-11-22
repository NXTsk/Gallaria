using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient.DTOs
{
    public class ArtistDto : PersonDto
    {
        [Required(ErrorMessage = "Profile description is required")]
        public string ProfileDescription { get; set; }
    }
}

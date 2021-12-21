using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gallaria.ApiClient.DTOs;
namespace Gallaria.WEB.ViewModels
{
    public class AccountViewModel
    {
        public ArtistDto? Artist { get; set; }
        public PersonDto Person { get; set; }
        public bool IsPersonArtist { get; set; }
    }
}

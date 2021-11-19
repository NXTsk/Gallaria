using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient.DTOs
{
    public class AddressDto
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}

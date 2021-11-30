using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallaria.API.Model
{
    public class AddressDto
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}

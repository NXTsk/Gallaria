using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    class Address
    {

        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Address(string street, string houseNumber, int zipcode, string city, string country)
        {
            Street = street;
            HouseNumber = houseNumber;
            Zipcode = zipcode;
            City = city;
            Country = country;
        }
    }
}

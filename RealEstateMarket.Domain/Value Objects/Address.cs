using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Domain.Value_Objects
{
    public class Address
    {
        public Address() { }
        public Address(string region, string city, ushort zipCode, string streetName, uint houseNumber)
        {
            Region = region;
            City = city;
            ZipCode = zipCode;
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public string Region { get; set; }
        public string City { get; set; }
        public ushort ZipCode { get; set; }
        public string StreetName { get; set; }
        public uint HouseNumber { get; set; }
    }
}

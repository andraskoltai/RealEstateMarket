using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Domain.Entities
{
    public class RealEstate
    {
        public Guid Id { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public short ZipCode { get; set; }

        public string StreetName { get; set; }

        public uint HouseNumber { get; set; }

        public string? Description { get; set; }

        public uint Price { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }
    }
}

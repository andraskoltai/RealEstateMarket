using System.ComponentModel.DataAnnotations;

namespace RealEstateMarket.Api.DTOs
{
    public class RealEstateDTO
    {
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

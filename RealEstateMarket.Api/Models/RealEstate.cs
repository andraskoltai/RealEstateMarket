using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateMarket.Api.Models
{
    [Table("Real estate")]
    public class RealEstate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string City { get; set; }

        [Range(1000, 9999)]
        public short ZipCode { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public uint HouseNumber { get; set; }

        public string? Description { get; set; }

        [Required]
        public uint Price { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }
    }
}

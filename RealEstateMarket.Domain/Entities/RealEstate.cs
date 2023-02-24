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
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Region { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; }

        [Required]
        public short ZipCode { get; set; }

        [Required, MaxLength(100)]
        public string StreetName { get; set; }

        [Required]
        public uint HouseNumber { get; set; }

        public string? Description { get; set; }

        [Required]
        public uint Price { get; set; }

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string? Email { get; set; }

        [StringLength(15, MinimumLength = 8), RegularExpression(@"^\+?\d+$")]
        public string? Phone { get; set; }
    }
}

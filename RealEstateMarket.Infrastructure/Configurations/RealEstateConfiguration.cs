using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateMarket.Domain.Entities;
using RealEstateMarket.Domain.Value_Objects;
using RealEstateMarket.Domain.Value_Objects.Ids;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Infrastructure.Configurations
{
    internal class RealEstateConfiguration : IEntityTypeConfiguration<RealEstate>
    {
        public void Configure(EntityTypeBuilder<RealEstate> builder)
        {
            builder.HasKey(re => re.Id);

            builder.Property(re => re.Id).HasConversion(
                realEstateId => realEstateId.Guid,
                value => new RealEstateId(value));

            builder.OwnsOne(re => re.Address, addressBuilder =>
            {
                addressBuilder.Property(a => a.Region).IsRequired().HasMaxLength(100);
                addressBuilder.Property(a => a.City).IsRequired().HasMaxLength(100);
                addressBuilder.Property(a => a.ZipCode).IsRequired();
                addressBuilder.Property(a => a.StreetName).IsRequired().HasMaxLength(100);
                addressBuilder.Property(a => a.HouseNumber).IsRequired();
            });

            builder.OwnsOne(re => re.Contacts, contactsBuilder =>
            {
                contactsBuilder.Property(c => c.Email).HasMaxLength(50);
                contactsBuilder.Property(c => c.Phone).HasMaxLength(15);
            });

            builder.Property(re => re.Price).IsRequired();

            builder.Property(re => re.Description).HasMaxLength(500);

            var realEstateGuid1 = Guid.NewGuid();
            var realEstateGuid2 = Guid.NewGuid();
            var realEstateGuid3 = Guid.NewGuid();
            builder.HasData(
                new RealEstate
                {
                    Id = new RealEstateId(realEstateGuid1),
                    Description = "leírás",
                    Price = 50000000
                },
                new RealEstate
                {
                    Id = new RealEstateId(realEstateGuid2),
                    Description = "leírás2",
                    Price = 380000000
                },
                new RealEstate
                {
                    Id = new RealEstateId(realEstateGuid3),
                    Description = "leírás3",
                    Price = 29000000
                }
            );

            builder.OwnsOne(re => re.Address).HasData(
                new
                {
                    RealEstateId = new RealEstateId(realEstateGuid1),
                    Region = "Pest",
                    City = "Budapest",
                    ZipCode = (ushort)1234,
                    StreetName = "Petőfi Sándor utca",
                    HouseNumber = (uint)10
                },
                new
                {
                    RealEstateId = new RealEstateId(realEstateGuid2),
                    Region = "Pest",
                    City = "Budapest",
                    ZipCode = (ushort)1234,
                    StreetName = "Kossuth Lajos utca",
                    HouseNumber = (uint)20
                },
                new
                {
                    RealEstateId = new RealEstateId(realEstateGuid3),
                    Region = "Zala",
                    City = "Zalaegerszeg",
                    ZipCode = (ushort)8900,
                    StreetName = "Arany János út",
                    HouseNumber = (uint)335
                }
                );

            builder.OwnsOne(re => re.Contacts).HasData(
                new
                {
                    RealEstateId = new RealEstateId(realEstateGuid1),
                    Email = "lorem@ipsum.net",
                    Phone = "+36301234567"
                },
                new
                {
                    RealEstateId = new RealEstateId(realEstateGuid2),
                    Email = (string?)null,
                    Phone = "+36302345678"
                },
                new
                {
                    RealEstateId = new RealEstateId(realEstateGuid3),
                    Email = (string?)null,
                    Phone = (string?)null
                }
                );
        }
    }
}

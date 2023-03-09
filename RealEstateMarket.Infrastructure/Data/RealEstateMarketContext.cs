using Microsoft.EntityFrameworkCore;
using RealEstateMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Infrastructure.Data
{
    public class RealEstateMarketContext : DbContext
    {
        public RealEstateMarketContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RealEstate> RealEstates { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealEstate>(re =>
            {
                re.HasKey(x => x.Id);
                re.Property(x => x.Guid).IsRequired();
                re.Property(x => x.Region).IsRequired().HasMaxLength(100);
                re.Property(x => x.City).IsRequired().HasMaxLength(100);
                re.Property(x => x.ZipCode).IsRequired();
                re.Property(x => x.StreetName).IsRequired().HasMaxLength(100);
                re.Property(x => x.HouseNumber).IsRequired();
                re.Property(x => x.Price).IsRequired();
                re.Property(x => x.City).HasMaxLength(15);
            });

            int seedId = 1;
            modelBuilder.Entity<RealEstate>().HasData(
                new RealEstate
                {
                    Id = seedId++,
                    Guid = Guid.NewGuid(),
                    Region = "Pest",
                    City = "Budapest",
                    ZipCode = 1234,
                    StreetName = "Petőfi Sándor utca",
                    HouseNumber = 10,
                    Description = "leírás",
                    Price = 50000000,
                    Email = "lorem@ipsum.net",
                    Phone = "+36301234567"
                },
                new RealEstate
                {
                    Id = seedId++,
                    Guid = Guid.NewGuid(),
                    Region = "Pest",
                    City = "Budapest",
                    ZipCode = 1234,
                    StreetName = "Kossuth Lajos utca",
                    HouseNumber = 10,
                    Price = 380000000,
                    Phone = "+36302345678"
                },
                new RealEstate
                {
                    Id = seedId++,
                    Guid = Guid.NewGuid(),
                    Region = "Zala",
                    City = "Zalaegerszeg",
                    ZipCode = 8900,
                    StreetName = "Arany János út",
                    HouseNumber = 335,
                    Description = "leírás2",
                    Price = 29000000,
                }
                );
        }
    }
}

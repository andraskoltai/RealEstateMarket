using Microsoft.EntityFrameworkCore;
using RealEstateMarket.Api.Models;

namespace RealEstateMarket.Api.Context
{
    public class RealEstateMarketContext : DbContext
    {
        public RealEstateMarketContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RealEstate> RealEstates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealEstate>().HasData(
                new RealEstate
                {
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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

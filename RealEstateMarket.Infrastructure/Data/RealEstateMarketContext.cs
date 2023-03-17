using Microsoft.EntityFrameworkCore;
using RealEstateMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
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
                // re.HasKey(x => x.Id);
                re.HasKey(x => x.Guid);
                //re.Property(x => x.Guid).IsRequired();
                re.Property(x => x.Region).IsRequired().HasMaxLength(100);
                re.Property(x => x.City).IsRequired().HasMaxLength(100);
                re.Property(x => x.ZipCode).IsRequired();
                re.Property(x => x.StreetName).IsRequired().HasMaxLength(100);
                re.Property(x => x.HouseNumber).IsRequired();
                re.Property(x => x.Price).IsRequired();
                re.Property(x => x.City).HasMaxLength(15);
            });

            //int seedId = 1;
            modelBuilder.Entity<RealEstate>().HasData(
                new RealEstate(
                    Guid.NewGuid(), "Pest", "Budapest",
                    1234, "Petőfi Sándor utca", 10,
                    "leírás", 50000000, "lorem@ipsum.net",
                    "+36301234567")
                ,
                new RealEstate(
                    Guid.NewGuid(), "Pest", "Budapest",
                    1234, "Kossuth Lajos utca", 10,
                    "leírás", 380000000, null,
                    "+36302345678")
                ,
                new RealEstate(
                    Guid.NewGuid(), "Zala", "Zalaegerszeg",
                    8900, "Arany János út", 335,
                    "leírás2", 29000000, null,
                    null)
                );

            modelBuilder.Entity<User>(u =>
            {
                // re.HasKey(x => x.Id);
                u.HasKey(x => x.Guid);
                //u.Property(x => x.Guid).IsRequired();
                u.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
                u.Property(x => x.LastName).IsRequired().HasMaxLength(100);
                u.Property(x => x.Email).IsRequired().HasMaxLength(100);
                u.Property(x => x.Password).IsRequired().HasMaxLength(100);
                u.Property(x => x.Phone).HasMaxLength(15);
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RealEstateMarket.Domain.Entities;
using RealEstateMarket.Domain.Value_Objects;
using RealEstateMarket.Domain.Value_Objects.Ids;
using RealEstateMarket.Infrastructure.Configurations;
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
            modelBuilder.ApplyConfiguration<RealEstate>(new RealEstateConfiguration());

            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(x => x.Guid);
                u.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
                u.Property(x => x.LastName).IsRequired().HasMaxLength(100);
                u.Property(x => x.Email).IsRequired().HasMaxLength(100);
                u.Property(x => x.Password).IsRequired().HasMaxLength(100);
                u.Property(x => x.Phone).HasMaxLength(15);
            });
        }
    }
}

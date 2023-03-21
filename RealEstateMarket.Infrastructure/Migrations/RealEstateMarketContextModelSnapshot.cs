﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstateMarket.Infrastructure.Data;

#nullable disable

namespace RealEstateMarket.Infrastructure.Migrations
{
    [DbContext(typeof(RealEstateMarketContext))]
    partial class RealEstateMarketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RealEstateMarket.Domain.Entities.RealEstate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("RealEstates");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e3fb5b1c-56f0-48af-b644-6508f6f5d522"),
                            Description = "leírás",
                            Price = 50000000L
                        },
                        new
                        {
                            Id = new Guid("1c1f7899-21b7-4f47-ab24-263294eb5424"),
                            Description = "leírás2",
                            Price = 380000000L
                        },
                        new
                        {
                            Id = new Guid("f29d433d-3245-406e-96ac-a329f1a88d6b"),
                            Description = "leírás3",
                            Price = 29000000L
                        });
                });

            modelBuilder.Entity("RealEstateMarket.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Guid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RealEstateMarket.Domain.Entities.RealEstate", b =>
                {
                    b.OwnsOne("RealEstateMarket.Domain.Value_Objects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("RealEstateId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<long>("HouseNumber")
                                .HasColumnType("bigint");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("StreetName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<int>("ZipCode")
                                .HasColumnType("int");

                            b1.HasKey("RealEstateId");

                            b1.ToTable("RealEstates");

                            b1.WithOwner()
                                .HasForeignKey("RealEstateId");

                            b1.HasData(
                                new
                                {
                                    RealEstateId = new Guid("e3fb5b1c-56f0-48af-b644-6508f6f5d522"),
                                    City = "Budapest",
                                    HouseNumber = 10L,
                                    Region = "Pest",
                                    StreetName = "Petőfi Sándor utca",
                                    ZipCode = 1234
                                },
                                new
                                {
                                    RealEstateId = new Guid("1c1f7899-21b7-4f47-ab24-263294eb5424"),
                                    City = "Budapest",
                                    HouseNumber = 20L,
                                    Region = "Pest",
                                    StreetName = "Kossuth Lajos utca",
                                    ZipCode = 1234
                                },
                                new
                                {
                                    RealEstateId = new Guid("f29d433d-3245-406e-96ac-a329f1a88d6b"),
                                    City = "Zalaegerszeg",
                                    HouseNumber = 335L,
                                    Region = "Zala",
                                    StreetName = "Arany János út",
                                    ZipCode = 8900
                                });
                        });

                    b.OwnsOne("RealEstateMarket.Domain.Value_Objects.Contacts", "Contacts", b1 =>
                        {
                            b1.Property<Guid>("RealEstateId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Email")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Phone")
                                .HasMaxLength(15)
                                .HasColumnType("nvarchar(15)");

                            b1.HasKey("RealEstateId");

                            b1.ToTable("RealEstates");

                            b1.WithOwner()
                                .HasForeignKey("RealEstateId");

                            b1.HasData(
                                new
                                {
                                    RealEstateId = new Guid("e3fb5b1c-56f0-48af-b644-6508f6f5d522"),
                                    Email = "lorem@ipsum.net",
                                    Phone = "+36301234567"
                                },
                                new
                                {
                                    RealEstateId = new Guid("1c1f7899-21b7-4f47-ab24-263294eb5424"),
                                    Phone = "+36302345678"
                                },
                                new
                                {
                                    RealEstateId = new Guid("f29d433d-3245-406e-96ac-a329f1a88d6b")
                                });
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Contacts")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

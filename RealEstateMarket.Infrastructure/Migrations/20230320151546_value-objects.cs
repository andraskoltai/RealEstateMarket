using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstateMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class valueobjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address_Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_ZipCode = table.Column<int>(type: "int", nullable: false),
                    Address_StreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_HouseNumber = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Contacts_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Contacts_Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Guid);
                });

            migrationBuilder.InsertData(
                table: "RealEstates",
                columns: new[] { "Id", "Description", "Price", "Address_City", "Address_HouseNumber", "Address_Region", "Address_StreetName", "Address_ZipCode", "Contacts_Email", "Contacts_Phone" },
                values: new object[,]
                {
                    { new Guid("1c1f7899-21b7-4f47-ab24-263294eb5424"), "leírás2", 380000000L, "Budapest", 20L, "Pest", "Kossuth Lajos utca", 1234, null, "+36302345678" },
                    { new Guid("e3fb5b1c-56f0-48af-b644-6508f6f5d522"), "leírás", 50000000L, "Budapest", 10L, "Pest", "Petőfi Sándor utca", 1234, "lorem@ipsum.net", "+36301234567" },
                    { new Guid("f29d433d-3245-406e-96ac-a329f1a88d6b"), "leírás3", 29000000L, "Zalaegerszeg", 335L, "Zala", "Arany János út", 8900, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstates");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

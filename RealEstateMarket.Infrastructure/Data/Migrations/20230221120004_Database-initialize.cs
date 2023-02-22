using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstateMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Databaseinitialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<short>(type: "smallint", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RealEstates",
                columns: new[] { "Id", "City", "Description", "Email", "HouseNumber", "Phone", "Price", "Region", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("1e48bfd5-00cb-40eb-91f3-b99af0aa5d96"), "Budapest", null, null, 10L, "+36302345678", 380000000L, "Pest", "Kossuth Lajos utca", (short)1234 },
                    { new Guid("80482d63-baf3-4a50-9bf8-86934f9f3776"), "Budapest", "leírás", "lorem@ipsum.net", 10L, "+36301234567", 50000000L, "Pest", "Petőfi Sándor utca", (short)1234 },
                    { new Guid("aa12f167-87a9-4c87-8d3b-e87b47705d65"), "Zalaegerszeg", "leírás2", null, 335L, null, 29000000L, "Zala", "Arany János út", (short)8900 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstates");
        }
    }
}

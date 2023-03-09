using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstateMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newdbwithintbasedkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ZipCode = table.Column<short>(type: "smallint", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RealEstates",
                columns: new[] { "Id", "City", "Description", "Email", "Guid", "HouseNumber", "Phone", "Price", "Region", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Budapest", "leírás", "lorem@ipsum.net", new Guid("a7d4e17c-9855-4bf9-a4fa-9bcfe8f7afab"), 10L, "+36301234567", 50000000L, "Pest", "Petőfi Sándor utca", (short)1234 },
                    { 2, "Budapest", null, null, new Guid("59078ece-9d5b-46d2-9f63-90c55cde56d5"), 10L, "+36302345678", 380000000L, "Pest", "Kossuth Lajos utca", (short)1234 },
                    { 3, "Zalaegerszeg", "leírás2", null, new Guid("eb771016-793d-4057-9d09-8f52ff2a6a13"), 335L, null, 29000000L, "Zala", "Arany János út", (short)8900 }
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

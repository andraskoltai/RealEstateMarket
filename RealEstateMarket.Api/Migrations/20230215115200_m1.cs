using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstateMarket.Api.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Real estate",
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
                    table.PrimaryKey("PK_Real estate", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Real estate",
                columns: new[] { "Id", "City", "Description", "Email", "HouseNumber", "Phone", "Price", "Region", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("5e256c66-e291-4f2d-8b90-c5f5f3f8e773"), "Budapest", null, null, 10L, "+36302345678", 380000000L, "Pest", "Kossuth Lajos utca", (short)1234 },
                    { new Guid("b3666060-38bb-4000-9963-d4c37727980d"), "Zalaegerszeg", "leírás2", null, 335L, null, 29000000L, "Zala", "Arany János út", (short)8900 },
                    { new Guid("cb4a0985-6f04-48e9-aed9-a186479ff088"), "Budapest", "leírás", "lorem@ipsum.net", 10L, "+36301234567", 50000000L, "Pest", "Petőfi Sándor utca", (short)1234 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Real estate");
        }
    }
}

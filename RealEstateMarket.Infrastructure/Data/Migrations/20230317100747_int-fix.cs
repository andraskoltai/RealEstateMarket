using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstateMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class intfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RealEstates",
                keyColumn: "Guid",
                keyValue: new Guid("0c9d83fb-ddc4-4ef5-8e61-3b7389549325"));

            migrationBuilder.DeleteData(
                table: "RealEstates",
                keyColumn: "Guid",
                keyValue: new Guid("2b068cfe-b545-4fad-af7c-740f8cedaade"));

            migrationBuilder.DeleteData(
                table: "RealEstates",
                keyColumn: "Guid",
                keyValue: new Guid("e326aad9-8969-4d45-a774-48b719379da0"));

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "RealEstates",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.InsertData(
                table: "RealEstates",
                columns: new[] { "Guid", "City", "Description", "Email", "HouseNumber", "Phone", "Price", "Region", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("73360b15-5956-4f22-ac80-e22bcc434920"), "Zalaegerszeg", "leírás2", null, 335L, null, 29000000L, "Zala", "Arany János út", 8900 },
                    { new Guid("8df097c3-ec03-4ba7-bb89-687e7f9f9653"), "Budapest", "leírás", "lorem@ipsum.net", 10L, "+36301234567", 50000000L, "Pest", "Petőfi Sándor utca", 1234 },
                    { new Guid("bffe48ce-29e2-4379-b577-9f8cd5946976"), "Budapest", "leírás", null, 10L, "+36302345678", 380000000L, "Pest", "Kossuth Lajos utca", 1234 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RealEstates",
                keyColumn: "Guid",
                keyValue: new Guid("73360b15-5956-4f22-ac80-e22bcc434920"));

            migrationBuilder.DeleteData(
                table: "RealEstates",
                keyColumn: "Guid",
                keyValue: new Guid("8df097c3-ec03-4ba7-bb89-687e7f9f9653"));

            migrationBuilder.DeleteData(
                table: "RealEstates",
                keyColumn: "Guid",
                keyValue: new Guid("bffe48ce-29e2-4379-b577-9f8cd5946976"));

            migrationBuilder.AlterColumn<short>(
                name: "ZipCode",
                table: "RealEstates",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "RealEstates",
                columns: new[] { "Guid", "City", "Description", "Email", "HouseNumber", "Phone", "Price", "Region", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("0c9d83fb-ddc4-4ef5-8e61-3b7389549325"), "Zalaegerszeg", "leírás2", null, 335L, null, 29000000L, "Zala", "Arany János út", (short)8900 },
                    { new Guid("2b068cfe-b545-4fad-af7c-740f8cedaade"), "Budapest", "leírás", "lorem@ipsum.net", 10L, "+36301234567", 50000000L, "Pest", "Petőfi Sándor utca", (short)1234 },
                    { new Guid("e326aad9-8969-4d45-a774-48b719379da0"), "Budapest", "leírás", null, 10L, "+36302345678", 380000000L, "Pest", "Kossuth Lajos utca", (short)1234 }
                });
        }
    }
}

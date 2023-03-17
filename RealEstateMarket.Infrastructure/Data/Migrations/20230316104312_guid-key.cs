using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstateMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class guidkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RealEstates",
                table: "RealEstates");

            migrationBuilder.DeleteData(
                table: "RealEstates",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RealEstates",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RealEstates",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RealEstates");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "Guid");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealEstates",
                table: "RealEstates",
                column: "Guid");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RealEstates",
                table: "RealEstates");

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

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Users",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RealEstates",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealEstates",
                table: "RealEstates",
                column: "Id");

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class Entities_Mapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Regions",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Regions",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Regions",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Difficulties",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Difficulties",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6ba7b810-9dad-41d1-80b4-00c04fd430c8"), "Hard" },
                    { new Guid("9c858901-8a57-4791-81fe-4c455b099bc9"), "Medium" },
                    { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("3a9e6c72-1f45-4b8d-b2c7-6e5a1d9f3048"), "WGN", "Wellington", "https://dummyjson.com/image/800x600/44aa88/ffffff?text=Wellington" },
                    { new Guid("7d1f93a6-2c58-4e74-b9a3-5f6d8c1b2047"), "OTA", "Otago", "https://dummyjson.com/image/800x600/6644aa/ffffff?text=Otago" },
                    { new Guid("8f7c2d1a-5b34-4e91-a7c2-1d6f9b8e3a45"), "AKL", "Auckland", "https://dummyjson.com/image/800x600/0088cc/ffffff?text=Auckland" },
                    { new Guid("c4b82e17-6d39-4f25-9a71-3e8c5b2d604f"), "CAN", "Canterbury", "https://dummyjson.com/image/800x600/aa8844/ffffff?text=Canterbury" },
                    { new Guid("e5a27c91-4b63-48d0-8f35-1c7e9a2b6054"), "WKO", "Waikato", "https://dummyjson.com/image/800x600/aa4466/ffffff?text=Waikato" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6ba7b810-9dad-41d1-80b4-00c04fd430c8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9c858901-8a57-4791-81fe-4c455b099bc9"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3a9e6c72-1f45-4b8d-b2c7-6e5a1d9f3048"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7d1f93a6-2c58-4e74-b9a3-5f6d8c1b2047"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8f7c2d1a-5b34-4e91-a7c2-1d6f9b8e3a45"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c4b82e17-6d39-4f25-9a71-3e8c5b2d604f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e5a27c91-4b63-48d0-8f35-1c7e9a2b6054"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Difficulties");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Difficulties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}

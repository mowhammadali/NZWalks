using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class Walks_Data_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LengthInKm", "Name", "RegionId", "WalkImageUrl" },
                values: new object[,]
                {
                    { new Guid("215fc389-fa83-43b9-bb5e-08df0b5447cd"), "One of New Zealand's most famous multi-day hiking tracks through spectacular mountains, forests, and valleys.", new Guid("9c858901-8a57-4791-81fe-4c455b099bc9"), 53.5, "Milford Track", new Guid("8f7c2d1a-5b34-4e91-a7c2-1d6f9b8e3a45"), "https://dummyjson.com/image/800x600/225588/ffffff?text=Milford+Track" },
                    { new Guid("5f16afa0-e33f-4bef-1a9d-08df0b2dbd77"), "A challenging hike near Wanaka with spectacular panoramic views of Lake Wanaka and the surrounding Southern Alps.", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), 16.0, "Roy's Peak Track", new Guid("c4b82e17-6d39-4f25-9a71-3e8c5b2d604f"), "https://dummyjson.com/image/800x600/228833/ffffff?text=Roy's+Peak+Track" },
                    { new Guid("a13f6c92-7e41-4b85-9d26-5c8a17f304be"), "A challenging alpine hike offering spectacular views across Taranaki and the surrounding landscapes.", new Guid("6ba7b810-9dad-41d1-80b4-00c04fd430c8"), 18.5, "Mount Taranaki Summit Track", new Guid("e5a27c91-4b63-48d0-8f35-1c7e9a2b6054"), "https://dummyjson.com/image/800x600/446688/ffffff?text=Mount+Taranaki+Summit+Track" },
                    { new Guid("b72e491c-35a8-4f67-a129-8d6c20e5b743"), "A scenic and accessible walk through native bush leading to panoramic views over Wellington city and harbour.", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), 5.2000000000000002, "Mount Victoria Lookout", new Guid("3a9e6c72-1f45-4b8d-b2c7-6e5a1d9f3048"), "https://dummyjson.com/image/800x600/228855/ffffff?text=Mount+Victoria+Lookout" },
                    { new Guid("c084fa5b-8caa-48d2-d26e-08df0b2e21f8"), "A scenic multi-day hike through native forests with beautiful views of Lake Waikaremoana and the surrounding wilderness.", new Guid("6ba7b810-9dad-41d1-80b4-00c04fd430c8"), 46.0, "Lake Waikaremoana Track", new Guid("7d1f93a6-2c58-4e74-b9a3-5f6d8c1b2047"), "https://dummyjson.com/image/800x600/336699/ffffff?text=Lake+Waikaremoana+Track" },
                    { new Guid("c46d8a21-9f53-47be-b630-1e7c95a2d804"), "A relaxing riverside walk through parks and native vegetation with beautiful views along the Waikato River.", new Guid("9c858901-8a57-4791-81fe-4c455b099bc9"), 8.4000000000000004, "Hamilton River Walk", new Guid("e5a27c91-4b63-48d0-8f35-1c7e9a2b6054"), "https://dummyjson.com/image/800x600/338866/ffffff?text=Hamilton+River+Walk" },
                    { new Guid("c720780a-1830-4b70-52ae-08df0b52e142"), "An easy and scenic walk through the Southern Alps with spectacular views of Aoraki Mount Cook, glaciers, rivers, and mountain landscapes.", new Guid("9c858901-8a57-4791-81fe-4c455b099bc9"), 10.0, "Hooker Valley Track", new Guid("8f7c2d1a-5b34-4e91-a7c2-1d6f9b8e3a45"), "https://dummyjson.com/image/800x600/884422/ffffff?text=Hooker+Valley+Track" },
                    { new Guid("d85b237a-61c4-49e8-a572-3f9b16c74028"), "A beautiful forest trail through lush native bush with waterfalls, streams, and impressive coastal views.", new Guid("9c858901-8a57-4791-81fe-4c455b099bc9"), 12.699999999999999, "Waitakere Ranges Trail", new Guid("8f7c2d1a-5b34-4e91-a7c2-1d6f9b8e3a45"), "https://dummyjson.com/image/800x600/557744/ffffff?text=Waitakere+Ranges+Trail" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("215fc389-fa83-43b9-bb5e-08df0b5447cd"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("5f16afa0-e33f-4bef-1a9d-08df0b2dbd77"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("a13f6c92-7e41-4b85-9d26-5c8a17f304be"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("b72e491c-35a8-4f67-a129-8d6c20e5b743"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("c084fa5b-8caa-48d2-d26e-08df0b2e21f8"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("c46d8a21-9f53-47be-b630-1e7c95a2d804"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("c720780a-1830-4b70-52ae-08df0b52e142"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("d85b237a-61c4-49e8-a572-3f9b16c74028"));
        }
    }
}

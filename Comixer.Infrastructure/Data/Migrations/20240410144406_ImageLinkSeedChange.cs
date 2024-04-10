using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comixer.Infrastructure.Data.Migrations
{
    public partial class ImageLinkSeedChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("528726ea-e421-4a80-b303-f035355599de"),
                column: "ConcurrencyStamp",
                value: "178184ca-56a1-4ea5-900e-d6a7fb0ec0a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5dd65fa9-eb2c-4372-8084-8c501347e74f"),
                column: "ConcurrencyStamp",
                value: "da315901-4dc1-4982-bf4b-8a33d1ea1049");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6738b013-93f3-4475-916d-ac89a37e0b04", "AQAAAAEAACcQAAAAEJRHCLOE0LtaechUYuNMcZ7s7r54N8sPS9vRfPuLF3fuyT4+OIhne9fDAQ0/KZ9GNA==", "3fc0af6e-2d79-49f1-80c7-ecca5eb4d37a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "169b56ec-0317-4dfd-839c-851f02e85bd7", "AQAAAAEAACcQAAAAELTrlhA9l448s5bxHe3t27LmJaYYWBjZkzZS/dC/RE0z9HP2iXSG0O35GwcZoQGQXQ==", "f0056851-c7f6-4110-9f3c-4fc96c9ee762" });

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e4dca4c6-f29f-459c-a6ce-85fcdb01b5c2"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 10, 17, 44, 5, 332, DateTimeKind.Local).AddTicks(5420));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 10, 17, 44, 5, 332, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("ed32b753-7a35-4512-99c0-e2216185686e"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 10, 17, 44, 5, 332, DateTimeKind.Local).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"),
                column: "CoverImageUrl",
                value: "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-15ca4f3c-4bb6-47b0-9d5f-e902c0627c91/cover.jpg");

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                column: "CoverImageUrl",
                value: "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-58b58581-82c8-4bbc-bcf3-49914b71bd00/cover.jpg");

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("cc41b9ea-0767-4a45-a7b4-37cb07bec4d3"),
                column: "CoverImageUrl",
                value: "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-cc41b9ea-0767-4a45-a7b4-37cb07bec4d3/cover.webp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("528726ea-e421-4a80-b303-f035355599de"),
                column: "ConcurrencyStamp",
                value: "cdfc619d-d19b-4600-a757-91caf9c84779");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5dd65fa9-eb2c-4372-8084-8c501347e74f"),
                column: "ConcurrencyStamp",
                value: "ece8ee49-ed95-4ecf-8c05-747c2a8fc760");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd1d7dbe-1858-4057-a240-1f16d9e3a107", "AQAAAAEAACcQAAAAEIs2jF8AoBm4EHuCv645LEm/40tdZNmMpiiCYESVoSPFUjjxq8C+PcgklckYKlt21A==", "47badf63-c3c2-41f4-9161-d74d28b45335" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a15e3888-b3a1-4b9a-a8ad-dbecbb4c3a4f", "AQAAAAEAACcQAAAAEMZLPYJNFjKuLh6FDrL2Gw+wr/neqD+0YpLU1GKaN5hF8oNxmMmOhx+ZMO1RGQ2UEA==", "1f7b95f0-457e-4ebb-924c-53559832dc8f" });

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e4dca4c6-f29f-459c-a6ce-85fcdb01b5c2"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 10, 17, 10, 40, 862, DateTimeKind.Local).AddTicks(2895));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 10, 17, 10, 40, 862, DateTimeKind.Local).AddTicks(2820));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("ed32b753-7a35-4512-99c0-e2216185686e"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 10, 17, 10, 40, 862, DateTimeKind.Local).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"),
                column: "CoverImageUrl",
                value: "https://res.cloudinary.com/dwyg7tvwc/image/upload/v1710970352/imeajdrdddoknxv69tml.jpg");

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                column: "CoverImageUrl",
                value: "https://res.cloudinary.com/dwyg7tvwc/image/upload/v1710970351/pmyfcdg55kslvyt0vlca.webp");

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("cc41b9ea-0767-4a45-a7b4-37cb07bec4d3"),
                column: "CoverImageUrl",
                value: "https://res.cloudinary.com/dwyg7tvwc/image/upload/v1710970352/imeajdrdddoknxv69tml.jpg");
        }
    }
}

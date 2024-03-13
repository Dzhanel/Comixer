using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comixer.Infrastructure.Data.Migrations
{
    public partial class AddCoverImageToComic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "Comics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("528726ea-e421-4a80-b303-f035355599de"),
                column: "ConcurrencyStamp",
                value: "26164cea-dc3d-4d1f-8f76-9d8d403539bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5dd65fa9-eb2c-4372-8084-8c501347e74f"),
                column: "ConcurrencyStamp",
                value: "88028258-4e3c-4307-a4c0-3d17a23e61b3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "366a1199-c9a4-47ce-bcdb-54fba9c8ae78", "AQAAAAEAACcQAAAAEEoqMPPCOrfGn21PZG8OLH+SjI1rAzlFghv2JkYBHAyVlTUv4ze085PGEWYI0M+Y7g==", "77e89ebe-4c26-4f6c-bb28-c026b7f34e8f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19a66cc7-5df9-41b4-83c2-519c7e97c99d", "AQAAAAEAACcQAAAAEGpFp8iSLv7Mn0ieX3xIQZKb4CFbpI8R5D8WM/xnkYAOjnADSs1LUF0qVeduP4XJnA==", "6b6e9105-56f0-4087-922e-ebd157bffc2f" });

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e4dca4c6-f29f-459c-a6ce-85fcdb01b5c2"),
                column: "ReleaseDate",
                value: new DateTime(2024, 3, 20, 23, 58, 52, 911, DateTimeKind.Local).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                column: "ReleaseDate",
                value: new DateTime(2024, 3, 20, 23, 58, 52, 911, DateTimeKind.Local).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("ed32b753-7a35-4512-99c0-e2216185686e"),
                column: "ReleaseDate",
                value: new DateTime(2024, 3, 20, 23, 58, 52, 911, DateTimeKind.Local).AddTicks(4138));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "Comics");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("528726ea-e421-4a80-b303-f035355599de"),
                column: "ConcurrencyStamp",
                value: "716c48e6-1de7-4e37-a6ac-f50c11ee4248");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5dd65fa9-eb2c-4372-8084-8c501347e74f"),
                column: "ConcurrencyStamp",
                value: "4858edc9-cbee-4615-a2d6-e536fb811e32");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c674b26a-0465-41e3-b847-ec342190927a", "AQAAAAEAACcQAAAAECiPSpvTM8fsTxuNyETuwVW3GXcryVJl4XGQ4JlHlvGiSUyx6TyzWDmwWSLjwo/yBQ==", "7a49967d-592f-4ffc-81a6-e21d1d01c3bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08a5b2e1-8a08-44ce-a95c-1bf90e0a15a9", "AQAAAAEAACcQAAAAEJ4qtnOJIPAJUzTW9fd95U/vtwy99wktIB1XSleBMWm9Ygz8/HVblPPFuiG+Lkez4A==", "61db8560-dc71-492d-8f49-7e864e41fdca" });

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e4dca4c6-f29f-459c-a6ce-85fcdb01b5c2"),
                column: "ReleaseDate",
                value: new DateTime(2024, 3, 18, 16, 20, 32, 504, DateTimeKind.Local).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                column: "ReleaseDate",
                value: new DateTime(2024, 3, 18, 16, 20, 32, 504, DateTimeKind.Local).AddTicks(5324));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("ed32b753-7a35-4512-99c0-e2216185686e"),
                column: "ReleaseDate",
                value: new DateTime(2024, 3, 18, 16, 20, 32, 504, DateTimeKind.Local).AddTicks(5385));
        }
    }
}

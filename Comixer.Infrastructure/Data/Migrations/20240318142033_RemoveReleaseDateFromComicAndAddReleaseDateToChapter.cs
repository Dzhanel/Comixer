using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comixer.Infrastructure.Data.Migrations
{
    public partial class RemoveReleaseDateFromComicAndAddReleaseDateToChapter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Comics");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Chapter",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Chapter");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Comics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("528726ea-e421-4a80-b303-f035355599de"),
                column: "ConcurrencyStamp",
                value: "d89d85a6-dca6-421c-8e96-2673dc85176a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5dd65fa9-eb2c-4372-8084-8c501347e74f"),
                column: "ConcurrencyStamp",
                value: "871d23d4-e406-43ed-a2d5-f54998228f7e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6a1e5b7-1b79-41f6-adbd-37c2cd302310", "AQAAAAEAACcQAAAAENERW1+Wfrqtq+GUdiCM+g2prNSYSZ8rCrXrt13NPoIGX9iamXvO8uaf0O1/03seQA==", "20bd38c3-550d-43f3-9856-40d7d40c3a23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cde88047-76a9-47fa-9103-7a040065f2d5", "AQAAAAEAACcQAAAAEEMSjxsEwydIfQAtoVvvHIx6NJhER0Vyn6jWvc0tf5/iA36EdtJbW1T6a+MgkI6a8Q==", "dcb7d0ba-a746-4f8a-9d01-dc85ef5b8daf" });

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"),
                column: "ReleaseDate",
                value: new DateTime(2024, 3, 12, 10, 15, 29, 335, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                column: "ReleaseDate",
                value: new DateTime(2024, 3, 12, 10, 15, 29, 335, DateTimeKind.Local).AddTicks(5452));

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("cc41b9ea-0767-4a45-a7b4-37cb07bec4d3"),
                column: "ReleaseDate",
                value: new DateTime(2024, 3, 12, 10, 15, 29, 335, DateTimeKind.Local).AddTicks(5497));
        }
    }
}

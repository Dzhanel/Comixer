using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comixer.Infrastructure.Data.Migrations
{
    public partial class DatabaseSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("528726ea-e421-4a80-b303-f035355599de"),
                column: "ConcurrencyStamp",
                value: "e3ba3c90-ed45-418d-b0ff-4fd0e7acd741");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5dd65fa9-eb2c-4372-8084-8c501347e74f"),
                column: "ConcurrencyStamp",
                value: "75719ea3-3200-4f10-9b67-d26eaabfdf7f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "073c2f9d-3db3-43c6-a87f-7a910f60150c", "AQAAAAEAACcQAAAAEHg6a4IZ8xdQDhdm2+iv3jAHzE6MPqZAaEpQCFr2fl2dvabriRcqh5X0f8wCzHzaBA==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16d0ca65-3d33-4597-87b6-56aca62add94", "AQAAAAEAACcQAAAAEJ4Eq3pJwGiZtWUDexbyG8p2ijynXa8NIzwH+Prlo7/SGYho477uPwqlN3SfULX3BA==", null });

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"),
                column: "ReleaseDate",
                value: new DateTime(2024, 3, 12, 0, 55, 8, 620, DateTimeKind.Local).AddTicks(954));

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                column: "ReleaseDate",
                value: new DateTime(2024, 3, 12, 0, 55, 8, 620, DateTimeKind.Local).AddTicks(999));

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("cc41b9ea-0767-4a45-a7b4-37cb07bec4d3"),
                column: "ReleaseDate",
                value: new DateTime(2024, 3, 12, 0, 55, 8, 620, DateTimeKind.Local).AddTicks(1004));
        }
    }
}

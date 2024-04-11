using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comixer.Infrastructure.Data.Migrations
{
    public partial class AddcommentTurnOffColumnToChapters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "ProhibitComments",
                table: "Chapter",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("528726ea-e421-4a80-b303-f035355599de"),
                column: "ConcurrencyStamp",
                value: "2eb857d6-b000-4379-9a1c-88ee78a2b906");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5dd65fa9-eb2c-4372-8084-8c501347e74f"),
                column: "ConcurrencyStamp",
                value: "799a3ea0-76a5-4802-bdb7-e5777a7b3311");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eeceb607-c35a-4a48-ab44-be7d5b5053dc", "AQAAAAEAACcQAAAAEHWBnCyY5iyfngVduSzqxWpo8IMMaV1LKIFsnPQm5NyQGX0O8YrYb+NRkcM4cEMGUg==", "0b1a0067-1bdd-481b-ad8d-d7eac1c100f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4faa5b9a-253f-41ae-beae-ed7127a52fe9", "AQAAAAEAACcQAAAAEKRuX+NAz92S/ggJ38uBmlC9SPOGJmsz+1ST7ZxG2GKTdeiKv5KepYULeIhGwAZoaQ==", "cf21e8c2-04b8-4ec7-a888-7dd0c159e33e" });

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e4dca4c6-f29f-459c-a6ce-85fcdb01b5c2"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 11, 17, 12, 5, 820, DateTimeKind.Local).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 11, 17, 12, 5, 820, DateTimeKind.Local).AddTicks(7338));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("ed32b753-7a35-4512-99c0-e2216185686e"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 11, 17, 12, 5, 820, DateTimeKind.Local).AddTicks(7415));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostDate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ProhibitComments",
                table: "Chapter");

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
        }
    }
}

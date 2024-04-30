using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comixer.Infrastructure.Data.Migrations
{
    public partial class AddComicApprovvedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Comics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("528726ea-e421-4a80-b303-f035355599de"),
                column: "ConcurrencyStamp",
                value: "25fe1ad0-0e1c-4fb4-be56-e807987a037a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5dd65fa9-eb2c-4372-8084-8c501347e74f"),
                column: "ConcurrencyStamp",
                value: "41c3a7d1-53ee-46c2-ab31-15c6c4197520");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fc40493-9ecd-41e8-9c34-53de225a4578", "AUTHOR 1", "AQAAAAEAACcQAAAAEOspfjPEb8IKr+/26/ZpM2J7NHGOn0fqtKRDI6cjjDfhyMDkPY9jyPVOrN7Mcko2Jg==", "22cad24e-2880-4d25-beb5-d95b8a83492f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e92945d-3e2e-471b-9cfc-393f50f45f43", "AQAAAAEAACcQAAAAECcDo98z845g/LLgH8TiJh9OqP9tUZajc061K0obSTGdTuMSizYjs8pC4N0LM7ux5w==", "e94cae94-4907-4dc3-839c-335e7a7d6c42" });

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e4dca4c6-f29f-459c-a6ce-85fcdb01b5c2"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 30, 14, 40, 45, 91, DateTimeKind.Local).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 27, 15, 40, 45, 91, DateTimeKind.Local).AddTicks(6276));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("ed32b753-7a35-4512-99c0-e2216185686e"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 29, 15, 40, 45, 91, DateTimeKind.Local).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3822dfdf-126f-473f-91ca-d84876f03306"),
                column: "PostDate",
                value: new DateTime(2024, 4, 30, 15, 39, 45, 93, DateTimeKind.Local).AddTicks(648));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c1d5d6c2-2b40-4f1e-a602-aea10f2bc24c"),
                column: "PostDate",
                value: new DateTime(2024, 4, 30, 14, 40, 45, 93, DateTimeKind.Local).AddTicks(627));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Comics");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("528726ea-e421-4a80-b303-f035355599de"),
                column: "ConcurrencyStamp",
                value: "d6d20f4a-5729-4eb0-bb62-30e4c3794721");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5dd65fa9-eb2c-4372-8084-8c501347e74f"),
                column: "ConcurrencyStamp",
                value: "5e72c08c-54df-425b-80b5-d21855313e8b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1502eb11-26ba-466e-8be2-ad11b007507f", "AUTHOR_1", "AQAAAAEAACcQAAAAEJEh+dlU+A4zfQ04cYNL3mG7+mL69BfEXBMa/XpWn4av0fjI//ctHvnNzSYegJOkXg==", "73abc3f4-cb13-40b1-8645-70b7b41f058a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d58f1a6-8ce6-41bf-8b4c-35966300aebe", "AQAAAAEAACcQAAAAEMlPyHn6yIGNL9kdxjbzfg3MkuHBvg5uoXmEgxaFEjChNEVnel1nJZ4FiXHDa+eqAA==", "69cdf1b8-b7ad-4c29-8e5e-2fee98100e1c" });

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e4dca4c6-f29f-459c-a6ce-85fcdb01b5c2"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 19, 7, 39, 14, 410, DateTimeKind.Local).AddTicks(5613));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 16, 8, 39, 14, 410, DateTimeKind.Local).AddTicks(5553));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("ed32b753-7a35-4512-99c0-e2216185686e"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 18, 8, 39, 14, 410, DateTimeKind.Local).AddTicks(5609));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3822dfdf-126f-473f-91ca-d84876f03306"),
                column: "PostDate",
                value: new DateTime(2024, 4, 19, 8, 38, 14, 412, DateTimeKind.Local).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c1d5d6c2-2b40-4f1e-a602-aea10f2bc24c"),
                column: "PostDate",
                value: new DateTime(2024, 4, 19, 7, 39, 14, 412, DateTimeKind.Local).AddTicks(1110));
        }
    }
}

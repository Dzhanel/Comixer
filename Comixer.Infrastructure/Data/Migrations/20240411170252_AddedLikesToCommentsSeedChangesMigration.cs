using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comixer.Infrastructure.Data.Migrations
{
    public partial class AddedLikesToCommentsSeedChangesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("528726ea-e421-4a80-b303-f035355599de"),
                column: "ConcurrencyStamp",
                value: "a9d2056a-3e30-4226-a793-613caba224b3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5dd65fa9-eb2c-4372-8084-8c501347e74f"),
                column: "ConcurrencyStamp",
                value: "23672930-bc99-497c-a959-736e59691fcf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b4f96e7-e4e9-4fa2-9fc5-973734ee5e5c", "AQAAAAEAACcQAAAAEAZyVZnZn2wOD8IDesRARES1g3VyGasVmL1NkMeYy5mNgewzUH7Yqgpi/sOyzfzpnQ==", "920d3caa-f049-4822-a7f0-2f0c80d24d80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abaeae53-1584-4ae2-b26b-1bcc9acca86e", "AQAAAAEAACcQAAAAEAVAyVDkFPaGehc98WhWdbFj6kNkrzNT+jqSvgCCjEzjWyAE8G07N0IxXZ1HIw472Q==", "4a5b9d43-0f61-4c0b-afba-0337cf71a012" });

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e4dca4c6-f29f-459c-a6ce-85fcdb01b5c2"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 11, 19, 2, 51, 709, DateTimeKind.Local).AddTicks(2983));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 8, 20, 2, 51, 709, DateTimeKind.Local).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("ed32b753-7a35-4512-99c0-e2216185686e"),
                column: "ReleaseDate",
                value: new DateTime(2024, 4, 10, 20, 2, 51, 709, DateTimeKind.Local).AddTicks(2977));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3822dfdf-126f-473f-91ca-d84876f03306"),
                column: "PostDate",
                value: new DateTime(2024, 4, 11, 20, 1, 51, 712, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c1d5d6c2-2b40-4f1e-a602-aea10f2bc24c"),
                column: "PostDate",
                value: new DateTime(2024, 4, 11, 19, 2, 51, 712, DateTimeKind.Local).AddTicks(1114));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Comments");

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

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3822dfdf-126f-473f-91ca-d84876f03306"),
                column: "PostDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c1d5d6c2-2b40-4f1e-a602-aea10f2bc24c"),
                column: "PostDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

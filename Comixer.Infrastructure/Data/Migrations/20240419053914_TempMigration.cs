using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comixer.Infrastructure.Data.Migrations
{
    public partial class TempMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParrentCommentID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParrentCommentID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsReadLater",
                table: "UsersComics");

            migrationBuilder.DropColumn(
                name: "ParrentCommentID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Chapter");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1502eb11-26ba-466e-8be2-ad11b007507f", "AQAAAAEAACcQAAAAEJEh+dlU+A4zfQ04cYNL3mG7+mL69BfEXBMa/XpWn4av0fjI//ctHvnNzSYegJOkXg==", "73abc3f4-cb13-40b1-8645-70b7b41f058a" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReadLater",
                table: "UsersComics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ParrentCommentID",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Chapter",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
                columns: new[] { "Rating", "ReleaseDate" },
                values: new object[] { 7.0, new DateTime(2024, 4, 11, 19, 2, 51, 709, DateTimeKind.Local).AddTicks(2983) });

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                columns: new[] { "Rating", "ReleaseDate" },
                values: new object[] { 4.0, new DateTime(2024, 4, 8, 20, 2, 51, 709, DateTimeKind.Local).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("ed32b753-7a35-4512-99c0-e2216185686e"),
                columns: new[] { "Rating", "ReleaseDate" },
                values: new object[] { 7.0, new DateTime(2024, 4, 10, 20, 2, 51, 709, DateTimeKind.Local).AddTicks(2977) });

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParrentCommentID",
                table: "Comments",
                column: "ParrentCommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParrentCommentID",
                table: "Comments",
                column: "ParrentCommentID",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}

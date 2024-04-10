using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comixer.Infrastructure.Data.Migrations
{
    public partial class IsReadLaterAddedToUserComic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Chapter");

            migrationBuilder.AddColumn<bool>(
                name: "IsReadLater",
                table: "UsersComics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CoverImageUrl",
                table: "Comics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("cc41b9ea-0767-4a45-a7b4-37cb07bec4d3"),
                column: "Status",
                value: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReadLater",
                table: "UsersComics");

            migrationBuilder.AlterColumn<string>(
                name: "CoverImageUrl",
                table: "Comics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Chapter",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "Description", "ReleaseDate" },
                values: new object[] { "Title Description", new DateTime(2024, 3, 20, 23, 58, 52, 911, DateTimeKind.Local).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                columns: new[] { "Description", "ReleaseDate" },
                values: new object[] { "Title Description", new DateTime(2024, 3, 20, 23, 58, 52, 911, DateTimeKind.Local).AddTicks(4076) });

            migrationBuilder.UpdateData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("ed32b753-7a35-4512-99c0-e2216185686e"),
                columns: new[] { "Description", "ReleaseDate" },
                values: new object[] { "Title Description", new DateTime(2024, 3, 20, 23, 58, 52, 911, DateTimeKind.Local).AddTicks(4138) });

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("cc41b9ea-0767-4a45-a7b4-37cb07bec4d3"),
                column: "Status",
                value: 3);
        }
    }
}

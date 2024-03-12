using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comixer.Infrastructure.Data.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComics_AspNetUsers_UserId",
                table: "UserComics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComics_Comics_ComicId",
                table: "UserComics");

            migrationBuilder.DropTable(
                name: "ComicGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserComics",
                table: "UserComics");

            migrationBuilder.RenameTable(
                name: "UserComics",
                newName: "UsersComics");

            migrationBuilder.RenameIndex(
                name: "IX_UserComics_ComicId",
                table: "UsersComics",
                newName: "IX_UsersComics_ComicId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParrentCommentID",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersComics",
                table: "UsersComics",
                columns: new[] { "UserId", "ComicId" });

            migrationBuilder.CreateTable(
                name: "ComicsGenres",
                columns: table => new
                {
                    ComicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicsGenres", x => new { x.GenreId, x.ComicId });
                    table.ForeignKey(
                        name: "FK_ComicsGenres_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicsGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("528726ea-e421-4a80-b303-f035355599de"), "e3ba3c90-ed45-418d-b0ff-4fd0e7acd741", "Administrator", "ADMINISTRATOR" },
                    { new Guid("5dd65fa9-eb2c-4372-8084-8c501347e74f"), "75719ea3-3200-4f10-9b67-d26eaabfdf7f", "Author", "AUTHOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"), 0, "073c2f9d-3db3-43c6-a87f-7a910f60150c", "author@comixer.com", false, false, null, "AUTHOR@COMIXER.COM", "AUTHOR_1", "AQAAAAEAACcQAAAAEHg6a4IZ8xdQDhdm2+iv3jAHzE6MPqZAaEpQCFr2fl2dvabriRcqh5X0f8wCzHzaBA==", null, false, null, false, "Author 1" },
                    { new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"), 0, "16d0ca65-3d33-4597-87b6-56aca62add94", "admin@comixer.com", false, false, null, "ADMIN@COMIXER.COM", "ADMIN", "AQAAAAEAACcQAAAAEJ4Eq3pJwGiZtWUDexbyG8p2ijynXa8NIzwH+Prlo7/SGYho477uPwqlN3SfULX3BA==", null, false, null, false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "Id", "Description", "ReleaseDate", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"), "Comic 1 Description", new DateTime(2024, 3, 12, 0, 55, 8, 620, DateTimeKind.Local).AddTicks(954), 1, "Comic 1" },
                    { new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"), "Comic 2 Description", new DateTime(2024, 3, 12, 0, 55, 8, 620, DateTimeKind.Local).AddTicks(999), 2, "Comic 2" },
                    { new Guid("cc41b9ea-0767-4a45-a7b4-37cb07bec4d3"), "Comic 3 Description", new DateTime(2024, 3, 12, 0, 55, 8, 620, DateTimeKind.Local).AddTicks(1004), 3, "Comic 3" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Comedy" },
                    { 3, "Action" },
                    { 4, "Slice Of Life" },
                    { 5, "Romance" },
                    { 6, "Superhero" },
                    { 7, "Sci-Fi" },
                    { 8, "Thriller" },
                    { 9, "Supernatural" },
                    { 10, "Mystery" },
                    { 11, "Sports" },
                    { 12, "Hystorical" },
                    { 13, "Horror" },
                    { 14, "Informative" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("528726ea-e421-4a80-b303-f035355599de"), new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f") });

            migrationBuilder.InsertData(
                table: "Chapter",
                columns: new[] { "Id", "ComicId", "Description", "Rating", "Title" },
                values: new object[,]
                {
                    { new Guid("e4dca4c6-f29f-459c-a6ce-85fcdb01b5c2"), new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"), "Title Description", 7.0, "Comic 2 Chapter 1" },
                    { new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"), new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"), "Title Description", 4.0, "Comic 1 Chapter 1" },
                    { new Guid("ed32b753-7a35-4512-99c0-e2216185686e"), new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"), "Title Description", 7.0, "Comic 1 Chapter 2" }
                });

            migrationBuilder.InsertData(
                table: "ComicsGenres",
                columns: new[] { "ComicId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"), 1 },
                    { new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"), 1 },
                    { new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"), 2 },
                    { new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"), 3 },
                    { new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"), 3 },
                    { new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"), 6 }
                });

            migrationBuilder.InsertData(
                table: "UsersComics",
                columns: new[] { "ComicId", "UserId", "IsArtist", "IsAuthor" },
                values: new object[] { new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"), new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"), true, true });

            migrationBuilder.InsertData(
                table: "ChapterImages",
                columns: new[] { "Id", "ChapterId", "ImagePath", "Position" },
                values: new object[,]
                {
                    { new Guid("2fac11ab-4de4-490c-86e0-a2a15aec5dc2"), new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"), "https://picsum.photos/1080/1920", 0 },
                    { new Guid("3e0ecc30-95d5-4c09-a63d-cc0329a8a47a"), new Guid("ed32b753-7a35-4512-99c0-e2216185686e"), "https://picsum.photos/1080/1920", 0 },
                    { new Guid("4b513b24-6ae1-4a1c-b274-82604c0cb848"), new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"), "https://picsum.photos/1080/1920", 1 },
                    { new Guid("d2b6ce95-5f30-4b34-a4c0-c23f8527760c"), new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"), "https://picsum.photos/1080/1920", 2 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ChapterId", "Content", "ParrentCommentID", "UserId" },
                values: new object[,]
                {
                    { new Guid("3822dfdf-126f-473f-91ca-d84876f03306"), new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"), "More comin' up soon!", null, new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d") },
                    { new Guid("c1d5d6c2-2b40-4f1e-a602-aea10f2bc24c"), new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"), "Awesome chapter!", null, new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComicsGenres_ComicId",
                table: "ComicsGenres",
                column: "ComicId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersComics_AspNetUsers_UserId",
                table: "UsersComics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersComics_Comics_ComicId",
                table: "UsersComics",
                column: "ComicId",
                principalTable: "Comics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersComics_AspNetUsers_UserId",
                table: "UsersComics");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersComics_Comics_ComicId",
                table: "UsersComics");

            migrationBuilder.DropTable(
                name: "ComicsGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersComics",
                table: "UsersComics");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5dd65fa9-eb2c-4372-8084-8c501347e74f"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("528726ea-e421-4a80-b303-f035355599de"), new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f") });

            migrationBuilder.DeleteData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e4dca4c6-f29f-459c-a6ce-85fcdb01b5c2"));

            migrationBuilder.DeleteData(
                table: "ChapterImages",
                keyColumn: "Id",
                keyValue: new Guid("2fac11ab-4de4-490c-86e0-a2a15aec5dc2"));

            migrationBuilder.DeleteData(
                table: "ChapterImages",
                keyColumn: "Id",
                keyValue: new Guid("3e0ecc30-95d5-4c09-a63d-cc0329a8a47a"));

            migrationBuilder.DeleteData(
                table: "ChapterImages",
                keyColumn: "Id",
                keyValue: new Guid("4b513b24-6ae1-4a1c-b274-82604c0cb848"));

            migrationBuilder.DeleteData(
                table: "ChapterImages",
                keyColumn: "Id",
                keyValue: new Guid("d2b6ce95-5f30-4b34-a4c0-c23f8527760c"));

            migrationBuilder.DeleteData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("cc41b9ea-0767-4a45-a7b4-37cb07bec4d3"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3822dfdf-126f-473f-91ca-d84876f03306"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c1d5d6c2-2b40-4f1e-a602-aea10f2bc24c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "UsersComics",
                keyColumns: new[] { "ComicId", "UserId" },
                keyValues: new object[] { new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"), new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("528726ea-e421-4a80-b303-f035355599de"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"));

            migrationBuilder.DeleteData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"));

            migrationBuilder.DeleteData(
                table: "Chapter",
                keyColumn: "Id",
                keyValue: new Guid("ed32b753-7a35-4512-99c0-e2216185686e"));

            migrationBuilder.DeleteData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"));

            migrationBuilder.RenameTable(
                name: "UsersComics",
                newName: "UserComics");

            migrationBuilder.RenameIndex(
                name: "IX_UsersComics_ComicId",
                table: "UserComics",
                newName: "IX_UserComics_ComicId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParrentCommentID",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserComics",
                table: "UserComics",
                columns: new[] { "UserId", "ComicId" });

            migrationBuilder.CreateTable(
                name: "ComicGenre",
                columns: table => new
                {
                    ComicsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicGenre", x => new { x.ComicsId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_ComicGenre_Comics_ComicsId",
                        column: x => x.ComicsId,
                        principalTable: "Comics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComicGenre_GenresId",
                table: "ComicGenre",
                column: "GenresId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComics_AspNetUsers_UserId",
                table: "UserComics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserComics_Comics_ComicId",
                table: "UserComics",
                column: "ComicId",
                principalTable: "Comics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

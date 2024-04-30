﻿// <auto-generated />
using System;
using Comixer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Comixer.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240430124045_AddComicApprovvedField")]
    partial class AddComicApprovvedField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6e92945d-3e2e-471b-9cfc-393f50f45f43",
                            Email = "admin@comixer.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@COMIXER.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAECcDo98z845g/LLgH8TiJh9OqP9tUZajc061K0obSTGdTuMSizYjs8pC4N0LM7ux5w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e94cae94-4907-4dc3-839c-335e7a7d6c42",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5fc40493-9ecd-41e8-9c34-53de225a4578",
                            Email = "author@comixer.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "AUTHOR@COMIXER.COM",
                            NormalizedUserName = "AUTHOR 1",
                            PasswordHash = "AQAAAAEAACcQAAAAEOspfjPEb8IKr+/26/ZpM2J7NHGOn0fqtKRDI6cjjDfhyMDkPY9jyPVOrN7Mcko2Jg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "22cad24e-2880-4d25-beb5-d95b8a83492f",
                            TwoFactorEnabled = false,
                            UserName = "Author 1"
                        });
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.Chapter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ComicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ProhibitComments")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("ComicId");

                    b.ToTable("Chapter");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                            ComicId = new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"),
                            ProhibitComments = false,
                            ReleaseDate = new DateTime(2024, 4, 27, 15, 40, 45, 91, DateTimeKind.Local).AddTicks(6276),
                            Title = "Comic 1 Chapter 1"
                        },
                        new
                        {
                            Id = new Guid("ed32b753-7a35-4512-99c0-e2216185686e"),
                            ComicId = new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"),
                            ProhibitComments = false,
                            ReleaseDate = new DateTime(2024, 4, 29, 15, 40, 45, 91, DateTimeKind.Local).AddTicks(6333),
                            Title = "Comic 1 Chapter 2"
                        },
                        new
                        {
                            Id = new Guid("e4dca4c6-f29f-459c-a6ce-85fcdb01b5c2"),
                            ComicId = new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                            ProhibitComments = false,
                            ReleaseDate = new DateTime(2024, 4, 30, 14, 40, 45, 91, DateTimeKind.Local).AddTicks(6337),
                            Title = "Comic 2 Chapter 1"
                        });
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.ChapterImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChapterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("ChapterImages");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2fac11ab-4de4-490c-86e0-a2a15aec5dc2"),
                            ChapterId = new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                            ImagePath = "https://picsum.photos/1080/1920",
                            Position = 0
                        },
                        new
                        {
                            Id = new Guid("4b513b24-6ae1-4a1c-b274-82604c0cb848"),
                            ChapterId = new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                            ImagePath = "https://picsum.photos/1080/1920",
                            Position = 1
                        },
                        new
                        {
                            Id = new Guid("d2b6ce95-5f30-4b34-a4c0-c23f8527760c"),
                            ChapterId = new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                            ImagePath = "https://picsum.photos/1080/1920",
                            Position = 2
                        },
                        new
                        {
                            Id = new Guid("3e0ecc30-95d5-4c09-a63d-cc0329a8a47a"),
                            ChapterId = new Guid("ed32b753-7a35-4512-99c0-e2216185686e"),
                            ImagePath = "https://picsum.photos/1080/1920",
                            Position = 0
                        });
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.Comic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CoverImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Comics");

                    b.HasData(
                        new
                        {
                            Id = new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"),
                            CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-15ca4f3c-4bb6-47b0-9d5f-e902c0627c91/cover.jpg",
                            Description = "Comic 1 Description",
                            IsApproved = false,
                            Status = 2,
                            Title = "Comic 1"
                        },
                        new
                        {
                            Id = new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                            CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-58b58581-82c8-4bbc-bcf3-49914b71bd00/cover.jpg",
                            Description = "Comic 2 Description",
                            IsApproved = false,
                            Status = 1,
                            Title = "Comic 2"
                        },
                        new
                        {
                            Id = new Guid("cc41b9ea-0767-4a45-a7b4-37cb07bec4d3"),
                            CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-cc41b9ea-0767-4a45-a7b4-37cb07bec4d3/cover.webp",
                            Description = "Comic 3 Description",
                            IsApproved = false,
                            Status = 0,
                            Title = "Comic 3"
                        });
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.ComicGenre", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<Guid>("ComicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GenreId", "ComicId");

                    b.HasIndex("ComicId");

                    b.ToTable("ComicsGenres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            ComicId = new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91")
                        },
                        new
                        {
                            GenreId = 2,
                            ComicId = new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91")
                        },
                        new
                        {
                            GenreId = 3,
                            ComicId = new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91")
                        },
                        new
                        {
                            GenreId = 1,
                            ComicId = new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00")
                        },
                        new
                        {
                            GenreId = 3,
                            ComicId = new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00")
                        },
                        new
                        {
                            GenreId = 6,
                            ComicId = new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00")
                        });
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChapterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c1d5d6c2-2b40-4f1e-a602-aea10f2bc24c"),
                            ChapterId = new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                            Content = "Awesome chapter!",
                            Likes = 0,
                            PostDate = new DateTime(2024, 4, 30, 14, 40, 45, 93, DateTimeKind.Local).AddTicks(627),
                            UserId = new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d")
                        },
                        new
                        {
                            Id = new Guid("3822dfdf-126f-473f-91ca-d84876f03306"),
                            ChapterId = new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                            Content = "More comin' up soon!",
                            Likes = 0,
                            PostDate = new DateTime(2024, 4, 30, 15, 39, 45, 93, DateTimeKind.Local).AddTicks(648),
                            UserId = new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d")
                        });
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Slice Of Life"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Superhero"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Supernatural"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Hystorical"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Informative"
                        });
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.UserComic", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ComicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsArtist")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAuthor")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "ComicId");

                    b.HasIndex("ComicId");

                    b.ToTable("UsersComics");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                            ComicId = new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"),
                            IsArtist = true,
                            IsAuthor = true
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("528726ea-e421-4a80-b303-f035355599de"),
                            ConcurrencyStamp = "25fe1ad0-0e1c-4fb4-be56-e807987a037a",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = new Guid("5dd65fa9-eb2c-4372-8084-8c501347e74f"),
                            ConcurrencyStamp = "41c3a7d1-53ee-46c2-ab31-15c6c4197520",
                            Name = "Author",
                            NormalizedName = "AUTHOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"),
                            RoleId = new Guid("528726ea-e421-4a80-b303-f035355599de")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.Chapter", b =>
                {
                    b.HasOne("Comixer.Infrastructure.Data.Entities.Comic", "Comic")
                        .WithMany("Chapters")
                        .HasForeignKey("ComicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comic");
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.ChapterImage", b =>
                {
                    b.HasOne("Comixer.Infrastructure.Data.Entities.Chapter", "Chapter")
                        .WithMany("ChapterImages")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.ComicGenre", b =>
                {
                    b.HasOne("Comixer.Infrastructure.Data.Entities.Comic", "Comic")
                        .WithMany("ComicGenres")
                        .HasForeignKey("ComicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Comixer.Infrastructure.Data.Entities.Genre", "Genre")
                        .WithMany("ComicsGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comic");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.Comment", b =>
                {
                    b.HasOne("Comixer.Infrastructure.Data.Entities.Chapter", "Chapter")
                        .WithMany("Comments")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Comixer.Infrastructure.Data.Entities.ApplicationUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.UserComic", b =>
                {
                    b.HasOne("Comixer.Infrastructure.Data.Entities.Comic", "Comic")
                        .WithMany("UsersComics")
                        .HasForeignKey("ComicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Comixer.Infrastructure.Data.Entities.ApplicationUser", "User")
                        .WithMany("UsersComics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Comixer.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Comixer.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Comixer.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Comixer.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("UsersComics");
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.Chapter", b =>
                {
                    b.Navigation("ChapterImages");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.Comic", b =>
                {
                    b.Navigation("Chapters");

                    b.Navigation("ComicGenres");

                    b.Navigation("UsersComics");
                });

            modelBuilder.Entity("Comixer.Infrastructure.Data.Entities.Genre", b =>
                {
                    b.Navigation("ComicsGenres");
                });
#pragma warning restore 612, 618
        }
    }
}

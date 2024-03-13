﻿// <auto-generated />
using System;
using Comixer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Comixer.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            ConcurrencyStamp = "19a66cc7-5df9-41b4-83c2-519c7e97c99d",
                            Email = "admin@comixer.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@COMIXER.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEGpFp8iSLv7Mn0ieX3xIQZKb4CFbpI8R5D8WM/xnkYAOjnADSs1LUF0qVeduP4XJnA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6b6e9105-56f0-4087-922e-ebd157bffc2f",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "366a1199-c9a4-47ce-bcdb-54fba9c8ae78",
                            Email = "author@comixer.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "AUTHOR@COMIXER.COM",
                            NormalizedUserName = "AUTHOR_1",
                            PasswordHash = "AQAAAAEAACcQAAAAEEoqMPPCOrfGn21PZG8OLH+SjI1rAzlFghv2JkYBHAyVlTUv4ze085PGEWYI0M+Y7g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "77e89ebe-4c26-4f6c-bb28-c026b7f34e8f",
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

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

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
                            Description = "Title Description",
                            Rating = 4.0,
                            ReleaseDate = new DateTime(2024, 3, 20, 23, 58, 52, 911, DateTimeKind.Local).AddTicks(4076),
                            Title = "Comic 1 Chapter 1"
                        },
                        new
                        {
                            Id = new Guid("ed32b753-7a35-4512-99c0-e2216185686e"),
                            ComicId = new Guid("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"),
                            Description = "Title Description",
                            Rating = 7.0,
                            ReleaseDate = new DateTime(2024, 3, 20, 23, 58, 52, 911, DateTimeKind.Local).AddTicks(4138),
                            Title = "Comic 1 Chapter 2"
                        },
                        new
                        {
                            Id = new Guid("e4dca4c6-f29f-459c-a6ce-85fcdb01b5c2"),
                            ComicId = new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                            Description = "Title Description",
                            Rating = 7.0,
                            ReleaseDate = new DateTime(2024, 3, 20, 23, 58, 52, 911, DateTimeKind.Local).AddTicks(4145),
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

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
                            CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/v1710970352/imeajdrdddoknxv69tml.jpg",
                            Description = "Comic 1 Description",
                            Status = 1,
                            Title = "Comic 1"
                        },
                        new
                        {
                            Id = new Guid("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                            CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/v1710970351/pmyfcdg55kslvyt0vlca.webp",
                            Description = "Comic 2 Description",
                            Status = 2,
                            Title = "Comic 2"
                        },
                        new
                        {
                            Id = new Guid("cc41b9ea-0767-4a45-a7b4-37cb07bec4d3"),
                            CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/v1710970352/imeajdrdddoknxv69tml.jpg",
                            Description = "Comic 3 Description",
                            Status = 3,
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

                    b.Property<Guid?>("ParrentCommentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.HasIndex("ParrentCommentID");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c1d5d6c2-2b40-4f1e-a602-aea10f2bc24c"),
                            ChapterId = new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                            Content = "Awesome chapter!",
                            UserId = new Guid("7386f2b2-a981-4944-ba58-12c6d42a595d")
                        },
                        new
                        {
                            Id = new Guid("3822dfdf-126f-473f-91ca-d84876f03306"),
                            ChapterId = new Guid("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                            Content = "More comin' up soon!",
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
                            ConcurrencyStamp = "26164cea-dc3d-4d1f-8f76-9d8d403539bc",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = new Guid("5dd65fa9-eb2c-4372-8084-8c501347e74f"),
                            ConcurrencyStamp = "88028258-4e3c-4307-a4c0-3d17a23e61b3",
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
                        .WithMany()
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
                        .WithMany()
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Comixer.Infrastructure.Data.Entities.Comment", "ParrentComment")
                        .WithMany()
                        .HasForeignKey("ParrentCommentID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Comixer.Infrastructure.Data.Entities.ApplicationUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");

                    b.Navigation("ParrentComment");

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
                        .WithMany()
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

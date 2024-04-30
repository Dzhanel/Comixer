using AutoMapper;
using Comixer.Core.Contracts;
using Comixer.Core.Extensions;
using Comixer.Core.Models.Comic;
using Comixer.Core.Service;
using Comixer.Infrastructure.Common;
using Comixer.Infrastructure.Data.Entities;
using Comixer.Infrastructure.Enums;
using Comixer.Tests.Mocks;
using Microsoft.EntityFrameworkCore;

namespace Comixer.Tests.Services
{
    [TestFixture]
    public class ComicsServiceTests
    {

        private ComicsService comicsService;
        private IMapper mapperMock = null!;
        private IImageService imageService = null!;
        private GenreService genreService;
        private IRepository repoMock;

        [SetUp]
        public void Setup()
        {
            mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationMappingProfile());
            }).CreateMapper();

            repoMock = new Repository(DbMock.Instance);
            genreService = new GenreService(mapperMock, repoMock);
            comicsService = new ComicsService(repoMock, mapperMock, imageService, genreService);
        }

        [Test]
        public async Task TakeRecentComicsReturns8Comics()
        {
            // Arrange
            var comics = new List<Comic>
            {
                new() {
                    Id = Guid.NewGuid(),
                    Title = "Comic 1",
                    Description = "Comic 1 Description",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-15ca4f3c-4bb6-47b0-9d5f-e902c0627c91/cover.jpg",
                    Status = Status.Completed,
                    IsApproved = true,
                    Chapters = new List<Chapter>
                    {
                        new() {
                            Title = "Chapter 1",
                            ReleaseDate = DateTime.Now
                        }
                    }
                },
                new() {
                    Id = Guid.NewGuid(),
                    Title = "Comic 2",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-58b58581-82c8-4bbc-bcf3-49914b71bd00/cover.jpg",
                    Description = "Comic 2 Description",
                    Status = Status.Releasing,
                    IsApproved = true,
                    Chapters = new List<Chapter>
                    {
                        new() {
                            Title = "Chapter 1",
                            ReleaseDate = DateTime.Now
                        }
                    }
                },
                new() {
                    Id = Guid.NewGuid(),
                    Title = "Comic 3",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-cc41b9ea-0767-4a45-a7b4-37cb07bec4d3/cover.webp",
                    Description = "Comic 3 Description",
                    Status = Status.NotYetReleased,
                    IsApproved = true,
                    Chapters = new List<Chapter>
                    {
                        new() {
                            Title = "Chapter 1",
                            ReleaseDate = DateTime.Now
                        }
                    }
                }
            };

            await repoMock.AddRangeAsync(comics);
            await repoMock.SaveChangesAsync();

            // Act
            var result = await comicsService.TakeRecentComics();

            // Assert
            Assert.That(result, Has.Count.EqualTo(comics.Count));
        }

        [Test]
        public async Task GetComicByIdReturnsComicDetailsModel()
        {
            // Arrange
            var comic = new Comic
            {
                Id = Guid.NewGuid(),
                Title = "Comic 1",
                Description = "Comic 1 Description",
                CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-15ca4f3c-4bb6-47b0-9d5f-e902c0627c91/cover.jpg",
                Status = Status.Completed,
                IsApproved = true,
                Chapters = new List<Chapter>
                {
                    new()
                    {
                        Title = "Chapter 1",
                        ReleaseDate = DateTime.Now
                    }
                }
            };

            await repoMock.AddAsync(comic);
            await repoMock.SaveChangesAsync();

            // Act
            var result = await comicsService.GetComicById(comic.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(comic.Id));
                Assert.That(result.Title, Is.EqualTo(comic.Title));
                Assert.That(result.Description, Is.EqualTo(comic.Description));
                Assert.That(result.CoverImageUrl, Is.EqualTo(comic.CoverImageUrl));
                Assert.That(result.Status, Is.EqualTo(comic.Status));
                Assert.That(result.IsApproved, Is.EqualTo(comic.IsApproved));
                Assert.That(result.Chapters, Has.Count.EqualTo(comic.Chapters.Count));
            });
        }

        [Test]
        public async Task GetComicsByAuthorIdReturnsComics()
        {
            // Arrange
            var authorId = Guid.NewGuid();
            var comics = new List<Comic>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Comic 1",
                    Description = "Comic 1 Description",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-15ca4f3c-4bb6-47b0-9d5f-e902c0627c91/cover.jpg",
                    Status = Status.Completed,
                    IsApproved = true,
                    UsersComics = new List<UserComic>
                    {
                        new()
                        {
                            UserId = authorId,
                            IsAuthor = true
                        }
                    }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Comic 2",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-58b58581-82c8-4bbc-bcf3-49914b71bd00/cover.jpg",
                    Description = "Comic 2 Description",
                    Status = Status.Releasing,
                    IsApproved = true,
                    UsersComics = new List<UserComic>
                    {
                        new()
                        {
                            UserId = authorId,
                            IsAuthor = true
                        }
                    }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Comic 3",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-cc41b9ea-0767-4a45-a7b4-37cb07bec4d3/cover.webp",
                    Description = "Comic 3 Description",
                    Status = Status.NotYetReleased,
                    IsApproved = true,
                    UsersComics = new List<UserComic>
                    {
                        new()
                        {
                            UserId = authorId,
                            IsAuthor = true
                        }
                    }
                }
            };

            await repoMock.AddRangeAsync(comics);
            await repoMock.SaveChangesAsync();

            // Act
            var result = await comicsService.GetComicsByAuthorId(authorId);

            // Assert
            Assert.That(result, Has.Count.EqualTo(comics.Count));
        }

        [Test]
        public async Task SearchReturnsComics()
        {
            // Arrange
            var comics = new List<Comic>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Comic 1",
                    Description = "Comic 1 Description",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-15ca4f3c-4bb6-47b0-9d5f-e902c0627c91/cover.jpg",
                    Status = Status.Completed,
                    IsApproved = true,
                    Chapters = new List<Chapter>
                    {
                        new()
                        {
                            Title = "Chapter 1",
                            ReleaseDate = DateTime.Now
                        }
                    },
                    ComicGenres = new List<ComicGenre>
                    {
                        new()
                        {
                            Genre = new Genre
                            {
                                Name = "Action"
                            }
                        }
                    }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Comic 2",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-58b58581-82c8-4bbc-bcf3-49914b71bd00/cover.jpg",
                    Description = "Comic 2 Description",
                    Status = Status.Releasing,
                    IsApproved = true,
                    Chapters = new List<Chapter>
                    {
                        new()
                        {
                            Title = "Chapter 1",
                            ReleaseDate = DateTime.Now
                        }
                    },
                    ComicGenres = new List<ComicGenre>
                    {
                        new()
                        {
                            Genre = new Genre
                            {
                                Name = "Action"
                            }
                        }
                    }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Comic 3",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-cc41b9ea-0767-4a45-a7b4-37cb07bec4d3/cover.webp",
                    Description = "Comic 3 Description",
                    Status = Status.NotYetReleased,
                    IsApproved = true,
                    Chapters = new List<Chapter>
                    {
                        new()
                        {
                            Title = "Chapter 1",
                            ReleaseDate = DateTime.Now
                        }
                    },
                    ComicGenres = new List<ComicGenre>
                    {
                        new()
                        {
                            Genre = new Genre
                            {
                                Name = "Action"
                            }
                        }
                    }
                }
            };
            // Add comics to the database
            await repoMock.AddRangeAsync(comics);
            await repoMock.SaveChangesAsync();
            //write the whole unit test
            // Act
            var result = await comicsService.Search("Comic 1", new List<string> { "Action" }, new List<string> { "Completed" }, "LastUpdated");
            // Assert
            Assert.That(result, Has.Count.EqualTo(1));
        }

        [Test]
        public async Task SearchReturnsComicsWhenGenresAreEmpty()
        {
            // Arrange
            var comics = new List<Comic>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Comic 1",
                    Description = "Comic 1 Description",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-15ca4f3c-4bb6-47b0-9d5f-e902c0627c91/cover.jpg",
                    Status = Status.Completed,
                    IsApproved = true,
                    Chapters = new List<Chapter>
                    {
                        new()
                        {
                            Title = "Chapter 1",
                            ReleaseDate = DateTime.Now
                        }
                    },
                    ComicGenres = new List<ComicGenre>
                    {
                        new()
                        {
                            Genre = new Genre
                            {
                                Name = "Action"
                            }
                        }
                    }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Comic 2",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-58b58581-82c8-4bbc-bcf3-49914b71bd00/cover.jpg",
                    Description = "Comic 2 Description",
                    Status = Status.Releasing,
                    IsApproved = true,
                    Chapters = new List<Chapter>
                    {
                        new()
                        {
                            Title = "Chapter 1",
                            ReleaseDate = DateTime.Now
                        }
                    },
                    ComicGenres = new List<ComicGenre>
                    {
                        new()
                        {
                            Genre = new Genre
                            {
                                Name = "Action"
                            }
                        }
                    }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Comic 3",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-cc41b9ea-0767-4a45-a7b4-37cb07bec4d3/cover.webp",
                    Description = "Comic 3 Description",
                    Status = Status.NotYetReleased,
                    IsApproved = true,
                    Chapters = new List<Chapter>
                    {
                        new()
                        {
                            Title = "Chapter 1",
                            ReleaseDate = DateTime.Now
                        }
                    },
                    ComicGenres = new List<ComicGenre>
                    {
                        new()
                        {
                            Genre = new Genre
                            {
                                Name = "Action"
                            }
                        }
                    }
                }
            };
            // Add comics to the database
            await repoMock.AddRangeAsync(comics);
            await repoMock.SaveChangesAsync();
            //write the whole unit test
            // Act
            var result = await comicsService.Search("Comic 1", new List<string>(), new List<string> { "Completed" }, "LastUpdated");
            // Assert
            Assert.That(result, Has.Count.EqualTo(1));

        }

        [Test]
        [TestCase("LastUpdated")]
        [TestCase("ChapterCount")]
        [TestCase("ReleaseDate")]
        [TestCase("Alphabetical")]
        public async Task SearchReturnsComicsWithDifferentSortings(string sorting)
        {
            // Arrange
            var comics = new List<Comic>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Comic 1",
                    Description = "Comic 1 Description",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-15ca4f3c-4bb6-47b0-9d5f-e902c0627c91/cover.jpg",
                    Status = Status.Completed,
                    IsApproved = true,
                    Chapters = new List<Chapter>
                    {
                        new()
                        {
                            Title = "Chapter 1",
                            ReleaseDate = DateTime.Now
                        }
                    },
                    ComicGenres = new List<ComicGenre>
                    {
                        new()
                        {
                            Genre = new Genre
                            {
                                Name = "Action"
                            }
                        }
                    }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Comic 2",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-58b58581-82c8-4bbc-bcf3-49914b71bd00/cover.jpg",
                    Description = "Comic 2 Description",
                    Status = Status.Releasing,
                    IsApproved = true,
                    Chapters = new List<Chapter>
                    {
                        new()
                        {
                            Title = "Chapter 1",
                            ReleaseDate = DateTime.Now
                        }
                    },
                    ComicGenres = new List<ComicGenre>
                    {
                        new()
                        {
                            Genre = new Genre
                            {
                                Name = "Action"
                            }
                        }
                    }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Comic 3",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-cc41b9ea-0767-4a45-a7b4-37cb07bec4d3/cover.webp",
                    Description = "Comic 3 Description",
                    Status = Status.NotYetReleased,
                    IsApproved = true,
                    Chapters = new List<Chapter>
                    {
                        new()
                        {
                            Title = "Chapter 1",
                            ReleaseDate = DateTime.Now
                        }
                    },
                    ComicGenres = new List<ComicGenre>
                    {
                        new()
                        {
                            Genre = new Genre
                            {
                                Name = "Action"
                            }
                        }
                    }
                }
            };
            // Add comics to the database
            await repoMock.AddRangeAsync(comics);
            await repoMock.SaveChangesAsync();
            //write the whole unit test
            // Act
            var result = await comicsService.Search("Comic 1", new List<string> { "Action" }, new List<string> { "Completed" }, sorting);
            // Assert
            Assert.That(result, Has.Count.EqualTo(1));
        }

        [Test]
        public async Task GetAuthorByComicIdReturnsAuthor()
        {
            var author = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = "Author",
                Email = "example@comixer.com"
            };
            await repoMock.AddAsync(author);
            // Arrange
            var comic = new Comic
            {
                Id = Guid.NewGuid(),
                Title = "Comic 1",
                Description = "Comic 1 Description",
                CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-15ca4f3c-4bb6-47b0-9d5f-e902c0627c91/cover.jpg",
                Status = Status.Completed,
                IsApproved = true,
                UsersComics = new List<UserComic>
                {
                    new()
                    {
                        User = author,
                        IsAuthor = true
                    }
                }
            };

            await repoMock.AddAsync(comic);
            await repoMock.SaveChangesAsync();

            // Act
            var result = await comicsService.GetAuthorByComicId(comic.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(author.Id));
        }
        [Test]
        public void GetAllStatusNamesReturnsStatusNames()
        {
            // Act
            var result = comicsService.GetAllStatusNames();

            // Assert
            Assert.That(result, Has.Count.EqualTo(Enum.GetNames(typeof(Status)).Length));
        }
        [Test]
        public void GetAllSortingNamesReturnsSortingNames()
        {
            // Act
            var result = comicsService.GetAllSortingNames();

            // Assert
            Assert.That(result, Has.Count.EqualTo(Enum.GetNames(typeof(Sorting)).Length));
        }

        [Test]
        public async Task ChangeToStatusChangesStatus()
        {
            // Arrange
            var comic = new Comic
            {
                Id = Guid.NewGuid(),
                Title = "Comic 1",
                Description = "Comic 1 Description",
                CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-15ca4f3c-4bb6-47b0-9d5f-e902c0627c91/cover.jpg",
                Status = Status.Completed,
                IsApproved = true
            };

            await repoMock.AddAsync(comic);
            await repoMock.SaveChangesAsync();

            // Act
            await comicsService.ChangeToStatus(Status.Releasing, comic.Id);
            Assert.Multiple(async () =>
            {
                // Assert
                Assert.That(await repoMock.GetByIdAsync<Comic>(comic.Id), Is.Not.Null);
                Assert.That((await repoMock.GetByIdAsync<Comic>(comic.Id)).Status, Is.EqualTo(Status.Releasing));
            });

        }

        [Test]
        public void ChangeToStatusThrowsExceptionWhenComicDoesNotExist()
        {
            // Arrange
            // Act
            // Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await comicsService.ChangeToStatus(Status.Releasing, Guid.Empty));
        }

        [Test]
        public async Task GetAuthorByComicIdThrowsExceptionWhenAuthorDoesNotHaveComics()
        {
            var comic = new Comic
            {
                Id = Guid.NewGuid(),
                Title = "Comic 1",
                Description = "Comic 1 Description",
                CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-15ca4f3c-4bb6-47b0-9d5f-e902c0627c91/cover.jpg",
                Status = Status.Completed,
                IsApproved = true
            };
            await repoMock.AddAsync(comic);
            // Act
            //Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await comicsService.GetAuthorByComicId(comic.Id));
        }

        [Test]
        public void GetComicByIdThrowsExceptionWhenComicDoesNotExist()
        {
            // Arrange
            // Act
            // Assert
            Assert.ThrowsAsync<KeyNotFoundException>(async () => await comicsService.GetComicById(Guid.Empty));
        }

        [Test]
        public async Task AddUserComicRelationAddsRelation()
        {
            // Arrange
            var comic = new Comic
            {
                Id = Guid.NewGuid(),
                Title = "Comic 1",
                Description = "Comic 1 Description",
                CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-15ca4f3c-4bb6-47b0-9d5f-e902c0627c91/cover.jpg",
                Status = Status.Completed,
                IsApproved = true
            };
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = "User",
                Email = "example@email.com"
            };
            await repoMock.AddAsync(comic);
            await repoMock.AddAsync(user);
            await repoMock.SaveChangesAsync();
            //Act
            await comicsService.AddUserComicRelation(comic.Id, user.Id, true, false);
            await repoMock.SaveChangesAsync();
            //Assert
            Assert.That(await repoMock.All<UserComic>().AnyAsync(x => x.ComicId == comic.Id && x.UserId == user.Id), Is.True);
        }
    }
}

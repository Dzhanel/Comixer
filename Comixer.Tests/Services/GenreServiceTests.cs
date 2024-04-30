using AutoMapper;
using Comixer.Core.Extensions;
using Comixer.Core.Models.Genre;
using Comixer.Core.Service;
using Comixer.Infrastructure;
using Comixer.Infrastructure.Common;
using Comixer.Infrastructure.Data.Entities;
using Comixer.Tests.Mocks;
using Moq;

namespace Comixer.Tests.Services
{
    [TestFixture]
    public class GenreServiceTests
    {
        private GenreService genreService;
        private IMapper mapperMock = null!;
        private ApplicationDbContext dbContext;
        private Repository repoMock;

        [SetUp]
        public void Setup()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationMappingProfile());
            });
            mapperMock = mapper.CreateMapper();

            dbContext = DbMock.Instance;
            repoMock = new Repository(dbContext);
            genreService = new GenreService(mapperMock, repoMock);
        }

        [Test]
        public async Task AddGenresToComicAsync_WithEmptyArray_DoesNotAddGenresToComic()
        {
            var comicId = Guid.NewGuid();
            var genreIds = new int[] { };

            // Act
            await genreService.AddGenresToComicAsync(genreIds, comicId);

            // Assert
            Assert.That(dbContext.ComicsGenres.Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task AddGenresToComicAsync_WithNullArray_DoesNotAddGenresToComic()
        {
            var comicId = Guid.NewGuid();
            int[] genreIds = null;

            // Act
            await genreService.AddGenresToComicAsync(genreIds, comicId);

            // Assert
            Assert.That(dbContext.ComicsGenres.Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task AddGenresToComicAsync_WithGenreIds_AddsCorrectGenresToComic()
        {
            //Arange
            var genreIds = new int[] { 1, 2, 3 };
            var comicId = Guid.NewGuid();
            var comic = new Comic { Id = comicId, Title = "Comic Title", Description = "Description", CoverImageUrl = "http://example.com" };
            await repoMock.AddAsync(comic);
            var genres = new List<Genre>
            {
                new() { Name = "Action" },
                new() { Name = "Adventure" },
                new() { Name = "Comedy" }
            };
            await repoMock.AddRangeAsync(genres);

            await repoMock.SaveChangesAsync();

            // Act
            await genreService.AddGenresToComicAsync(genreIds, comicId);
            await repoMock.SaveChangesAsync();

            // Assert
            Assert.That(dbContext.ComicsGenres.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task GetGenresByComicId_ValidComicId_ReturnsGenreModels()
        {
            // Arrange
            var comicId = Guid.NewGuid();
            var comic = new Comic { Id = comicId, Title = "Comic Title", Description = "Description", CoverImageUrl = "http://example.com" };
            await repoMock.AddAsync(new ComicGenre { Comic = comic, Genre = new Genre { Id = 1, Name = "Action" } });
            await repoMock.SaveChangesAsync();
            var result = await genreService.GetGenresByComicId(comicId);

            Assert.That(result, Is.Not.Null); 
        }
        [Test]
        public async Task GetAllGenresAsync_ReturnsGenreModels()
        {
            // Arrange
            var genres = new List<Genre>
            {
                new() { Name = "Action" },
                new() { Name = "Adventure" },
                new() { Name = "Comedy" }
            };
            await repoMock.AddRangeAsync(genres);
            await repoMock.SaveChangesAsync();

            // Act
            var result = await genreService.AllGenresAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
        }

    }
}

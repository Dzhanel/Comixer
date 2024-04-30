using AutoMapper;
using Comixer.Core.Contracts;
using Comixer.Core.Extensions;
using Comixer.Core.Models.Chapter;
using Comixer.Core.Service;
using Comixer.Infrastructure.Common;
using Comixer.Infrastructure.Data.Entities;
using Comixer.Infrastructure.Enums;
using Comixer.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Comixer.Tests.Services
{
    public class ChapterServiceTests
    {
        private ChapterService chapterService;
        private IMapper mapperMock = null!;
        private IImageService imageService = null!;
        private IRepository repoMock;

        [SetUp]
        public void Setup()
        {
            mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationMappingProfile());
            }).CreateMapper();

            repoMock = new Repository(DbMock.Instance);
            chapterService = new ChapterService(repoMock, mapperMock, imageService);
        }
        [Test]
        public async Task MarkComicAsCompletedAsync_ReturnsTrue()
        {

            // Arrange
            var comicId = Guid.NewGuid();
            var comic = new Comic
            {
                Id = comicId,
                Title = "Comic Title",
                CoverImageUrl = "coverImageUrl",
                Description = "description",
            };
            await repoMock.AddAsync(comic);
            await repoMock.SaveChangesAsync();
            // Act
            await chapterService.MarkAsCompleted(comicId);
            // Assert that the comic is marked as completed
            var result = await repoMock.GetByIdAsync<Comic>(comic.Id);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.EqualTo(Status.Completed));
        }

        [Test]
        public async Task GetPreviousFiveChapters_ReturnsChapterDropDownModel()
        {
            // Arrange
            var comicId = Guid.NewGuid();
            var comic = new Comic
            {
                Id = comicId,
                Title = "Comic Title",
                CoverImageUrl = "coverImageUrl",
                Description = "description",
            };
            await repoMock.AddAsync(comic);
            await repoMock.SaveChangesAsync();

            var chapter = new Chapter
            {
                Id = Guid.NewGuid(),
                Title = "Chapter Title",
                ComicId = comicId,
                ReleaseDate = DateTime.Now
            };
            await repoMock.AddAsync(chapter);
            await repoMock.SaveChangesAsync();

            // Act
            var result = await chapterService.GetPreviousFiveChapters(chapter.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetNextChapterAsync_ReturnsNullIfNoNextChapter()
        {
            // Arrange
            var comicId = Guid.NewGuid();
            var comic = new Comic
            {
                Id = comicId,
                Title = "Comic Title",
                CoverImageUrl = "coverImageUrl",
                Description = "description",
            };
            await repoMock.AddAsync(comic);
            await repoMock.SaveChangesAsync();

            var chapter = new Chapter
            {
                Id = Guid.NewGuid(),
                Title = "Chapter Title",
                ComicId = comicId,
                ReleaseDate = DateTime.Now
            };
            await repoMock.AddAsync(chapter);
            await repoMock.SaveChangesAsync();

            // Act
            var result = await chapterService.GetNextChapterAsync(chapter.Id);

            // Assert
            Assert.That(result, Is.Null);
        }
        [Test]
        public async Task GetPreviousChapterAsync_ReturnsNullIfNoPreviousChapter()
        {
            // Arrange
            var comicId = Guid.NewGuid();
            var comic = new Comic
            {
                Id = comicId,
                Title = "Comic Title",
                CoverImageUrl = "coverImageUrl",
                Description = "description",
            };
            await repoMock.AddAsync(comic);
            await repoMock.SaveChangesAsync();

            var chapter = new Chapter
            {
                Id = Guid.NewGuid(),
                Title = "Chapter Title",
                ComicId = comicId,
                ReleaseDate = DateTime.Now
            };
            await repoMock.AddAsync(chapter);
            await repoMock.SaveChangesAsync();

            // Act
            var result = await chapterService.GetPreviousChapterAsync(chapter.Id);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetChapterContentAsync_ReturnsChapterContentModel()
        {
            // Arrange
            var comicId = Guid.NewGuid();
            var comic = new Comic
            {
                Id = comicId,
                Title = "Comic Title",
                CoverImageUrl = "coverImageUrl",
                Description = "description",
            };
            await repoMock.AddAsync(comic);
            await repoMock.SaveChangesAsync();

            var chapter = new Chapter
            {
                Id = Guid.NewGuid(),
                Title = "Chapter Title",
                ComicId = comicId,
                ReleaseDate = DateTime.Now
            };
            await repoMock.AddAsync(chapter);
            await repoMock.SaveChangesAsync();

            var chapterImage = new ChapterImage
            {
                Id = Guid.NewGuid(),
                ChapterId = chapter.Id,
                ImagePath = "imagePath"
            };
            await repoMock.AddAsync(chapterImage);
            await repoMock.SaveChangesAsync();

            // Act
            var result = await chapterService.GetChapterContentAsync(chapter.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ChapterImages.Count, Is.EqualTo(1));
        }

    }
}

using AutoMapper;
using Comixer.Core.Extensions;
using Comixer.Core.Models.Comment;
using Comixer.Core.Service;
using Comixer.Infrastructure;
using Comixer.Infrastructure.Common;
using Comixer.Infrastructure.Data.Entities;
using Comixer.Tests.Mocks;
using Moq;
using NUnit.Framework.Internal;
using NUnit.Framework;
using Comixer.Core.Contracts;
namespace Comixer.Tests.Services
{
    [TestFixture]
    public class CommentServiceTests
    {
        private ICommentService commentService;
        private IMapper mapperMock = null!;
        private ApplicationDbContext dbContext;

        [SetUp]
        public void Setup()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationMappingProfile());
            });
            mapperMock = mapper.CreateMapper();

            dbContext = DbMock.Instance;
            var repoMock = new Repository(dbContext);

            commentService = new CommentService(mapperMock, repoMock);
        }
        [Test]
        public async Task AddComment_ValidData_AddsCommentToDatabaseAndReturnsCommentId()
        {
            // Arrange
            var model = new AddCommentModel
            {
                ChapterId = Guid.NewGuid(),
                Content = "This is a sample comment content."
            };
            var userId = Guid.NewGuid();

            // Act
            var commentId = await commentService.AddComment(model, userId);

            // Assert
            Assert.That(commentId, Is.Not.EqualTo(Guid.Empty));

            var addedComment = dbContext.Comments.FirstOrDefault(c => c.Id == commentId);
            Assert.That(addedComment, Is.Not.Null);
        }

        [Test]
        public async Task GetCommentsByChapterId_ReturnsCommentsWithUsers()
        {
            // Arrange
            var chapterId = Guid.NewGuid();
            var user1 = new ApplicationUser { Id = Guid.NewGuid(), UserName = "John Doe" };
            var user2 = new ApplicationUser { Id = Guid.NewGuid(), UserName = "Jane Doe" };

            dbContext.AddRange(
              new Comment { Id = Guid.NewGuid(), ChapterId = chapterId, Content = "Comment 1", PostDate = DateTime.Now, User = user1 },
              new Comment { Id = Guid.NewGuid(), ChapterId = chapterId, Content = "Comment 2", PostDate = DateTime.Now, User = user2 }
            );
            dbContext.SaveChanges();

            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(r => r.AllReadonly<Comment>()).Returns(dbContext.Comments.AsQueryable());

            commentService = new CommentService(mapperMock, mockRepo.Object);

            // Act
            var result = await commentService.GetCommentsByChapterId(chapterId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.All(c => c.Username != null));
        }
        [Test]
        public void AddComment_SaveFailure_ThrowsException()
        {
            // Arrange
            var model = new AddCommentModel
            {
                ChapterId = Guid.NewGuid(),
                Content = "This is a sample comment content."
            };
            var userId = Guid.NewGuid();

            // Mock the repository to simulate save failure
            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(0);

            commentService = new CommentService(mapperMock, mockRepo.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await commentService.AddComment(model, userId));
        }

    }
}

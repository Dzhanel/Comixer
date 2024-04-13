using AutoMapper;
using Comixer.Core.Contracts;
using Comixer.Core.Models.Comment;
using Comixer.Infrastructure.Common;
using Comixer.Infrastructure.Data.Entities;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace Comixer.Core.Service
{
    public class CommentService : ICommentService
    {
        private readonly IMapper mapper;
        private readonly IRepository repo;
        public CommentService(IMapper mapper, IRepository repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        public async Task AddComment(AddCommentModel model, Guid userId)
        {
            var entity = mapper.Map<AddCommentModel, Comment>(model);
            entity.Id = Guid.NewGuid();
            entity.UserId = userId;
            entity.PostDate = DateTime.Now;
            await repo.AddAsync<Comment>(entity);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<CommentModel>> GetCommentsByChapterId(Guid chapterId)
        {
            var result = await repo.AllReadonly<Comment>()
                .Where(c => c.ChapterId == chapterId)
                .OrderByDescending(x => x.PostDate)
                .ThenBy(x => x.Likes)
                .Include(c => c.User)
                .Select(c => mapper.Map<Comment, CommentModel>(c))
                .ToListAsync();

            return result;
        }
    }
}

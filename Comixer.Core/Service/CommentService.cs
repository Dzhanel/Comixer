using AutoMapper;
using Comixer.Core.Contracts;
using Comixer.Core.Models.Comment;
using Comixer.Infrastructure.Common;
using Comixer.Infrastructure.Data.Entities;
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

        public async Task<IEnumerable<CommentModel>> GetCommentsByChapterId(Guid comicId)
        {
            var result = await repo.AllReadonly<Comment>()
                .Where(c => c.Id == c.ChapterId)
                .Include(c => c.User)
                .Select(c => mapper.Map<Comment, CommentModel>(c))
                .ToListAsync();

            return result;
        }
    }
}

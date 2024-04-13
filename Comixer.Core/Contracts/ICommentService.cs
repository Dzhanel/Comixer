using Comixer.Core.Models.Comment;

namespace Comixer.Core.Contracts
{
    public interface ICommentService
    {
        public Task AddComment(AddCommentModel model, Guid userId);
        public Task<IEnumerable<CommentModel>> GetCommentsByChapterId(Guid id);
    }
}

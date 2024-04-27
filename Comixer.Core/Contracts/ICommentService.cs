using Comixer.Core.Models.Comment;

namespace Comixer.Core.Contracts
{
    public interface ICommentService
    {
        /// <summary>
        /// Adds comment to the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<Guid> AddComment(AddCommentModel model, Guid userId);
        public Task<List<CommentModel>> GetCommentsByChapterId(Guid id);
    }
}

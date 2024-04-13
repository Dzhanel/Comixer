using System.ComponentModel.DataAnnotations;
using static Comixer.Common.Constants.Comments;

namespace Comixer.Core.Models.Comment
{
    public class AddCommentModel
    {
        public Guid ChapterId { get; set; }
        [Required]
        [StringLength(CommentContentMaxLength, MinimumLength = CommentContentMinLength)]
        public string Content { get; set; } = null!;
    }
}

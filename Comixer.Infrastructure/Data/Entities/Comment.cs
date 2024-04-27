using Comixer.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Comixer.Common.Constants.Comments;

namespace Comixer.Infrastructure.Data.Entities
{
    [EntityTypeConfiguration(typeof(CommentConfiguration))]
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(CommentContentMaxLength)]
        public string Content { get; set; } = null!;
        public DateTime PostDate { get ; set; }
        //[AllowNull]
        //[ForeignKey(nameof(ParrentComment))]
        //public Guid? ParrentCommentID { get; set; }
        //[AllowNull]
        //public Comment ParrentComment { get; set; }

        [ForeignKey(nameof(Chapter))]
        public Guid ChapterId { get; set; }
        public Chapter Chapter { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
        public Guid UserId { get; set; }
        public int Likes { get; set; }

        public override string ToString()
        {
            return $"{User} - {Content}";
        }
    }
}

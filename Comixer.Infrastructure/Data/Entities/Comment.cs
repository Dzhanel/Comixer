using Comixer.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Comixer.Infrastructure.Data.Entities
{
    [EntityTypeConfiguration(typeof(CommentConfiguration))]
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Content { get; set; } = null!;
        [AllowNull]
        [ForeignKey(nameof(ParrentComment))]
        public Guid? ParrentCommentID { get; set; }
        [AllowNull]
        public Comment ParrentComment { get; set; }

        [ForeignKey(nameof(Chapter))]
        public Guid ChapterId { get; set; }
        public Chapter Chapter { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}

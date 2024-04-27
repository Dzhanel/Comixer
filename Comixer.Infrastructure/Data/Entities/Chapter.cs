using Comixer.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using static Comixer.Common.Constants.Chapter;

namespace Comixer.Infrastructure.Data.Entities
{
    [EntityTypeConfiguration(typeof(ChapterConfiguration))]
    public class Chapter
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;
        [AllowNull]
        public DateTime ReleaseDate { get; set; }
        //public double Rating { get; set; }
        [ForeignKey(nameof(Comic))]
        public Guid ComicId { get; set; }
        public Comic Comic { get; set; } = null!;
        public IEnumerable<ChapterImage> ChapterImages { get; set; } = new HashSet<ChapterImage>();
        public IEnumerable<Comment> Comments { get; set; } = new HashSet<Comment>();
        public bool ProhibitComments { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Id}";
        }
    }
}

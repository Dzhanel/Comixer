using Comixer.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Comixer.Infrastructure.Data.Entities
{
    [EntityTypeConfiguration(typeof(ChapterConfiguration))]
    public class Chapter
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Title { get; set; } = null!;
        [AllowNull]
        [MaxLength(300)]
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        [ForeignKey(nameof(Comic))]
        public Guid ComicId { get; set; }
        public Comic Comic { get; set; } = null!;
        public IEnumerable<ChapterImage> ChapterImages { get; set; } = new HashSet<ChapterImage>();
    }
}

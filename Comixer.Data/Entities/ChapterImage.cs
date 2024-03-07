using Comixer.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comixer.Data.Entities
{
    [EntityTypeConfiguration(typeof(ChapterImageConfiguration))]
    public class ChapterImage
    {
        [Key]
        public Guid Id { get; set; }
        public int Position { get; set; }
        public string ImagePath { get; set; } = null!;
        [ForeignKey(nameof(Chapter))]
        public Guid ChapterId { get; set; }
        public Chapter Chapter { get; set; } = null!;
    }
}

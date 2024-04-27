using Comixer.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comixer.Infrastructure.Data.Entities
{
    [EntityTypeConfiguration(typeof(ChapterImageConfiguration))]
    public class ChapterImage
    {
        [Key]
        public Guid Id { get; set; }
        public int Position { get; set; }
        public string ImagePath { get; set; } = null!;
        public Guid ChapterId { get; set; }
        [ForeignKey(nameof(ChapterId))]
        public Chapter Chapter { get; set; } = null!;

        public override string ToString()
        {
            return $"{ImagePath}";
        }
    }
}

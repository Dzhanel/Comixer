using Comixer.Infrastructure.Data.Configurations;
using Comixer.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static Comixer.Common.Constants.Comic;

namespace Comixer.Infrastructure.Data.Entities
{
    [EntityTypeConfiguration(typeof(ComicConfiguration))]
    public class Comic
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;
        [AllowNull]
        [MaxLength(DescriptionMaxLength)]
        [DataType("Markdown")]
        public string Description { get; set; }
        public Status Status { get; set; }
        public string CoverImageUrl { get; set; } = null!;
        public ICollection<Chapter> Chapters { get; set; } = new HashSet<Chapter>();
        public ICollection<UserComic> UsersComics { get; set; } = new HashSet<UserComic>();
        public ICollection<ComicGenre> ComicGenres { get; set; } = new HashSet<ComicGenre>();
        public override string ToString()
        {
            return $"{Title} - {Id}";
        }
    }
}

using Comixer.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Comixer.Infrastructure.Data.Entities
{
    [EntityTypeConfiguration(typeof(GenreConfiguration))]
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public ICollection<ComicGenre> ComicsGenres { get; set; } = new HashSet<ComicGenre>();
    }
}

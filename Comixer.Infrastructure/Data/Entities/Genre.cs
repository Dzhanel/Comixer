using Comixer.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Comixer.Common.Constants.Genre;

namespace Comixer.Infrastructure.Data.Entities
{
    [EntityTypeConfiguration(typeof(GenreConfiguration))]
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(GenreMaxNameLength)]
        public string Name { get; set; } = null!;
        public ICollection<ComicGenre> ComicsGenres { get; set; } = new HashSet<ComicGenre>();
        public override string ToString()
        {
            return Name;
        }
    }
}

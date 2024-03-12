using Comixer.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comixer.Infrastructure.Data.Entities
{
    [EntityTypeConfiguration(typeof(ComicGenreConfiguration))]
    public class ComicGenre
    {
        [ForeignKey(nameof(ComicId))]
        public Guid ComicId { get; set; }
        public Comic Comic { get; set; } = null!;
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
    }
}

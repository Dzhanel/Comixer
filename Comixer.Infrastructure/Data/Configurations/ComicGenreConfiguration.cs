using Comixer.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comixer.Infrastructure.Data.Configurations
{
    public class ComicGenreConfiguration : IEntityTypeConfiguration<ComicGenre>
    {
        public void Configure(EntityTypeBuilder<ComicGenre> builder)
        {
            builder
                .HasKey(g => new { g.GenreId, g.ComicId });
            builder.HasData(SeedComicGenres());
        }

        private ICollection<ComicGenre> SeedComicGenres()
        {
            return new HashSet<ComicGenre>
            {
                new()
                {
                    ComicId = Guid.Parse("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"),
                    GenreId = 1
                },
                new()
                {
                    ComicId = Guid.Parse("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"),
                    GenreId = 2
                },
                new()
                {
                    ComicId = Guid.Parse("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"),
                    GenreId = 3
                },
                new()
                {
                    ComicId = Guid.Parse("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                    GenreId = 1
                },
                new()
                {
                    ComicId = Guid.Parse("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                    GenreId = 3
                },
                new()
                {
                    ComicId = Guid.Parse("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                    GenreId = 6
                }
            };
        }
    }
}

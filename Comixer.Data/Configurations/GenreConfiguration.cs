using Comixer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comixer.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(SeedGenres());
        }
        private static ICollection<Genre> SeedGenres()
        {
            HashSet<Genre> result = new();
            string[] genres = { "Drama", "Fantasy", "Comedy", "Action", "Slice Of Life", "Romance", "Superhero", "Sci-Fi", "Thriller", "Supernatural", "Mystery", "Sports", "Hystorical", "Horror", "Informative" };
            for (int i = 1; i < genres.Length; i++)
            {
                result.Add(new Genre()
                {
                    Id = i,
                    Name = genres[i],
                });
            }
            return result;
        }
    }
}

using Comixer.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comixer.Infrastructure.Data.Configurations
{
    public class ComicConfiguration : IEntityTypeConfiguration<Comic>
    {
        public void Configure(EntityTypeBuilder<Comic> comicBuilder)
        {
            comicBuilder.HasData(SeedComics());
        }

        private static ICollection<Comic> SeedComics()
        {
            return new HashSet<Comic>
            {
                new()
                {
                    Id = Guid.Parse("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91"),
                    Title = "Comic 1",
                    Description = "Comic 1 Description",
                    ReleaseDate = DateTime.Now,
                    Status = 1,
                },
                new()
                {
                    Id = Guid.Parse("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                    Title = "Comic 2",
                    Description = "Comic 2 Description",
                    ReleaseDate = DateTime.Now,
                    Status = 2,
                },
                new()
                {
                    Id = Guid.Parse("cc41b9ea-0767-4a45-a7b4-37cb07bec4d3"),
                    Title = "Comic 3",
                    Description = "Comic 3 Description",
                    ReleaseDate = DateTime.Now,
                    Status = 3,
                }
           };
        }

    }
}

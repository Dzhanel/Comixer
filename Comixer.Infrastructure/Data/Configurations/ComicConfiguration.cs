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
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/v1710970352/imeajdrdddoknxv69tml.jpg",
                    Status = 1,
                },
                new()
                {
                    Id = Guid.Parse("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                    Title = "Comic 2",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/v1710970351/pmyfcdg55kslvyt0vlca.webp",
                    Description = "Comic 2 Description",
                    Status = 2,
                },
                new()
                {
                    Id = Guid.Parse("cc41b9ea-0767-4a45-a7b4-37cb07bec4d3"),
                    Title = "Comic 3",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/v1710970352/imeajdrdddoknxv69tml.jpg",
                    Description = "Comic 3 Description",
                    Status = 3,
                }
           };
        }

    }
}

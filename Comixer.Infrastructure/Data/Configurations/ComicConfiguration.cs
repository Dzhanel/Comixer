using Comixer.Infrastructure.Data.Entities;
using Comixer.Infrastructure.Enums;
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
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-15ca4f3c-4bb6-47b0-9d5f-e902c0627c91/cover.jpg",
                    Status = Status.Completed,
                },
                new()
                {
                    Id = Guid.Parse("58b58581-82c8-4bbc-bcf3-49914b71bd00"),
                    Title = "Comic 2",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-58b58581-82c8-4bbc-bcf3-49914b71bd00/cover.jpg",
                    Description = "Comic 2 Description",
                    Status = Status.Releasing,
                },
                new()
                {
                    Id = Guid.Parse("cc41b9ea-0767-4a45-a7b4-37cb07bec4d3"),
                    Title = "Comic 3",
                    CoverImageUrl = "https://res.cloudinary.com/dwyg7tvwc/image/upload/comic-cc41b9ea-0767-4a45-a7b4-37cb07bec4d3/cover.webp",
                    Description = "Comic 3 Description",
                    Status = Status.NotYetReleased,
                }
           };
        }

    }
}

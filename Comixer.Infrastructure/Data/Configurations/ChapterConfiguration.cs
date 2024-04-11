using Comixer.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Comixer.Infrastructure.Data.Configurations
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.HasData(SeedChapters());
        }

        private static ICollection<Chapter> SeedChapters()
        {
            return new HashSet<Chapter>
            {
                new()
                {
                    Id = Guid.Parse("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                    Title = "Comic 1 Chapter 1",
                    ReleaseDate = DateTime.Now.AddDays(-3),
                    Rating = 4,
                    ComicId = Guid.Parse("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91")
                },
                new()
                {
                    Id = Guid.Parse("ed32b753-7a35-4512-99c0-e2216185686e"),
                    Title = "Comic 1 Chapter 2",
                    ReleaseDate = DateTime.Now.AddDays(-1),
                    Rating = 7,
                    ComicId = Guid.Parse("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91")
                },
                new()
                {
                    Id = Guid.Parse("e4dca4c6-f29f-459c-a6ce-85fcdb01b5c2"),
                    Title = "Comic 2 Chapter 1",
                    ReleaseDate = DateTime.Now.AddHours(-1),
                    Rating = 7,
                    ComicId = Guid.Parse("58b58581-82c8-4bbc-bcf3-49914b71bd00")
                }
            };
        }
    }
}

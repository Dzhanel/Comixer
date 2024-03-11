using Comixer.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comixer.Infrastructure.Data.Configurations
{
    public class ChapterImageConfiguration : IEntityTypeConfiguration<ChapterImage>
    {
        public void Configure(EntityTypeBuilder<ChapterImage> builder)
        {
            builder.HasData(SeedChapterImages());
        }

        private static ICollection<ChapterImage> SeedChapterImages()
        {
            return new HashSet<ChapterImage> {
                new()
                {
                    Id =  Guid.Parse("2fac11ab-4de4-490c-86e0-a2a15aec5dc2"),
                    Position = 0,
                    ImagePath = "https://picsum.photos/1080/1920",
                    ChapterId = Guid.Parse("e5a73c63-1bef-425b-aaf7-425d55d21767")
                },
                new()
                {
                    Id =  Guid.Parse("4b513b24-6ae1-4a1c-b274-82604c0cb848"),
                    Position = 1,
                    ImagePath = "https://picsum.photos/1080/1920",
                    ChapterId = Guid.Parse("e5a73c63-1bef-425b-aaf7-425d55d21767")
                },
                new()
                {
                    Id =  Guid.Parse("d2b6ce95-5f30-4b34-a4c0-c23f8527760c"),
                    Position = 2,
                    ImagePath = "https://picsum.photos/1080/1920",
                    ChapterId = Guid.Parse("e5a73c63-1bef-425b-aaf7-425d55d21767")
                },
                new()
                {
                    Id =  Guid.Parse("3e0ecc30-95d5-4c09-a63d-cc0329a8a47a"),
                    Position = 0,
                    ImagePath = "https://picsum.photos/1080/1920",
                    ChapterId = Guid.Parse("ed32b753-7a35-4512-99c0-e2216185686e")
                }
            };
        }
    }
}

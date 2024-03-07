using Comixer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comixer.Data.Configurations
{
    public class UserComicConfiguration : IEntityTypeConfiguration<UserComic>
    {
        public void Configure(EntityTypeBuilder<UserComic> builder)
        {
            builder
                .HasKey(g => new { g.UserId, g.ComicId });
            
            builder.HasData(SeedUsersComics());
        }

        private static ICollection<UserComic> SeedUsersComics()
        {
            return new HashSet<UserComic>
            {
                new()
                {
                    IsArtist = true,
                    IsAuthor = true,
                    UserId = Guid.Parse("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                    ComicId = Guid.Parse("15ca4f3c-4bb6-47b0-9d5f-e902c0627c91")
                }
            };
        }
    }
}

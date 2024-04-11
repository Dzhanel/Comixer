using Comixer.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comixer.Infrastructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x => x.ParrentComment)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(SeedComments());
        }

        private static ICollection<Comment> SeedComments()
        {
            return new HashSet<Comment>
            {
                new()
                {
                    Id = Guid.Parse("c1d5d6c2-2b40-4f1e-a602-aea10f2bc24c"),
                    Content = "Awesome chapter!",
                    ChapterId = Guid.Parse("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                    UserId = Guid.Parse("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                    PostDate = DateTime.Now.AddHours(-1),
                    ParrentCommentID = null
                },
                new()
                {
                    Id = Guid.Parse("3822dfdf-126f-473f-91ca-d84876f03306"),
                    PostDate = DateTime.Now.AddMinutes(-1),
                    Content = "More comin' up soon!",
                    ChapterId = Guid.Parse("e5a73c63-1bef-425b-aaf7-425d55d21767"),
                    UserId = Guid.Parse("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                    ParrentCommentID = null
                }
            };
        }
    }
}

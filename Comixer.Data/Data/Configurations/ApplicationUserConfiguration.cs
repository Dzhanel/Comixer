using Comixer.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comixer.Infrastructure.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(SeedUsers());
        }

        private static ICollection<ApplicationUser> SeedUsers()
        {
            var users = new HashSet<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var admin = new ApplicationUser()
            {
                Id = Guid.Parse("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"),
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@comixer.com",
                NormalizedEmail = "ADMIN@COMIXER.COM",
            };
            //TODO: This is development purpose only admin password, re-implement if goes to deployment
            admin.PasswordHash = hasher.HashPassword(admin, "Admin123#");
            users.Add(admin);

            var author = new ApplicationUser()
            {
                Id = Guid.Parse("7386f2b2-a981-4944-ba58-12c6d42a595d"),
                UserName = "Author 1",
                NormalizedUserName = "AUTHOR_1",
                Email = "author@comixer.com",
                NormalizedEmail = "AUTHOR@COMIXER.COM",
            };
            //TODO: This is development purpose only admin password, re-implement if goes to deployment
            author.PasswordHash = hasher.HashPassword(author, "Author123#");
            users.Add(author);

            return users;
        }
    }
}

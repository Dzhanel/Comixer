using Comixer.Data.Configurations;
using Comixer.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Comixer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Chapter> Chapter { get; set; } = null!;
        public DbSet<ChapterImage> ChapterImages { get; set; } = null!;
        public DbSet<Comic> Comics { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!; 
        public DbSet<UserComic> UsersComics { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<ComicGenre> ComicsGenres { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
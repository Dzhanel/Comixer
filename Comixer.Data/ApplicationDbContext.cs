using Comixer.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Comixer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Chapter> Chpater { get; set; } = null!;
        public DbSet<ChapterImage> ChapterImages { get; set; } = null!;
        public DbSet<Comic> Comics { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!; 
        public DbSet<UserComic> UserComics { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserComic>()
                .HasKey(g => new { g.UserId, g.ComicId });

            builder.Entity<Comment>()
                .HasOne(x => x.ParrentComment)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
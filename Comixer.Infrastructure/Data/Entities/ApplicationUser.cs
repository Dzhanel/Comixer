using Comixer.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Comixer.Infrastructure.Data.Entities
{
    [EntityTypeConfiguration(typeof(ApplicationUserConfiguration))]
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public ICollection<UserComic> UsersComics { get; set; } = new HashSet<UserComic>();
    }
}
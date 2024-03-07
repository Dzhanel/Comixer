using Comixer.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Comixer.Data.Entities
{
    [EntityTypeConfiguration(typeof(ApplicationUserConfiguration))]
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ICollection<Comment> Comments { get; set; } = null!;
    }
}
using Microsoft.AspNetCore.Identity;

namespace Comixer.Data.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ICollection<Comment> Comments { get; set; } = null!;
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comixer.Infrastructure.Data.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasData(SeedUserRole());
        }

        private static ICollection<IdentityUserRole<Guid>> SeedUserRole()
        {
            return new HashSet<IdentityUserRole<Guid>>
            {
                new()
                {
                    UserId = Guid.Parse("c6c34844-3e79-4c96-bd46-6aeb571a2d2f"),
                    RoleId = Guid.Parse("528726ea-e421-4a80-b303-f035355599de")
                }
            };
        }
    }
}

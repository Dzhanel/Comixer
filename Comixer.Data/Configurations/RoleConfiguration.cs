using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comixer.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(SeedRoles());
        }

        private static ICollection<IdentityRole<Guid>> SeedRoles()
        {
            return new HashSet<IdentityRole<Guid>>
            {
                new()
                {
                    Id = Guid.Parse("528726ea-e421-4a80-b303-f035355599de"),
                    Name = "Administrator",
                    NormalizedName= "ADMINISTRATOR",
                },
                new()
                {
                    Id = Guid.Parse("5dd65fa9-eb2c-4372-8084-8c501347e74f"),
                    Name = "Author",
                    NormalizedName= "AUTHOR",
                }
            };
        }
    }
}

using Core.Auh.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityDb.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public List<IdentityRole> Roles { get; set; }

        public RoleConfiguration()
        {
            Roles = Roles = new List<IdentityRole>();
            foreach (UserRolesEnum userRole in (UserRolesEnum[])Enum.GetValues(typeof(UserRolesEnum)))
            {
                Roles.Add(new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = userRole.ToString(),
                    NormalizedName = userRole.ToString().ToUpper()
                });
            };
        }

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            
            builder.HasData(Roles);
        }
    }
}

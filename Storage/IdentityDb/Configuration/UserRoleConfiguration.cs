using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityDb.Configuration
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        //public List<IdentityUserRole> Users { get; set; }
        private Dictionary<string, string> UserRoleDictionary;
        private List<IdentityUserRole<string>> identityUserRoles;
        
        public UserRoleConfiguration(Dictionary<string, string> userRoleDictionary)
        {
            UserRoleDictionary = userRoleDictionary;
            identityUserRoles = userRoleDictionary.Select(d => new IdentityUserRole<string> {
                RoleId = d.Value,
                UserId = d.Key
            }).ToList();
        }

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            // Each Role can have many entries in the UserRole join table
            // builder.Navigation(o => o.UserId).
            builder.HasData(identityUserRoles);
        }
        
        
    }
}

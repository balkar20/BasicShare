using Core.Auh.Entities;
using Core.Auh.Enums;
using IdentityDb.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Data.IdentityDb
{
    public class ApplicationContext : IdentityDbContext<UserEntity>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var userManager = Database.GetService<UserManager<UserEntity>>();
            var roleManager = Database.GetService<RoleManager<IdentityRole>>();
            var roleConfig = new RoleConfiguration();
            var userConfig = new UserConfiguration();

            builder.ApplyConfiguration(roleConfig);
            builder.ApplyConfiguration(userConfig);
            
            var adminRoleId = roleConfig.Roles.FirstOrDefault(r => r.Name == UserRolesEnum.Administrator.ToString()).Id;
            var pooperRoleId = roleConfig.Roles.FirstOrDefault(r => r.Name == UserRolesEnum.Pooper.ToString()).Id;
            // var userId = userConfig.Users.FirstOrDefault(u => u.UserName == "admin").Id;
            var userRoleDictionary = new Dictionary<string, string>();
            foreach (var userConfigUser in userConfig.Users)
            {
                if (userConfigUser.UserName.Contains("Balkar"))
                {
                    userRoleDictionary.Add(userConfigUser.Id, adminRoleId);
                    continue;
                }
                if (userConfigUser.UserName != null) userRoleDictionary.Add(userConfigUser.Id, pooperRoleId);
            }

            var userRoleConfig = new UserRoleConfiguration(userRoleDictionary);
            builder.ApplyConfiguration(userRoleConfig);

            base.OnModelCreating(builder);
        }
    }
}

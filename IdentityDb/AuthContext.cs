using System.Security.Claims;
using Core.Auh.Entities;
using Core.Auh.Enums;
using Core.Base.DataBase.Entities;
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
        
        public DbSet<PooperEntity> Poopers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //todo:  decompose logic from user to pooper
            builder.Entity<PooperEntity>().ToTable("Poopers");
            builder.Entity<PooperEntity>().HasOne<UserEntity>();
            
            var userManager = Database.GetService<UserManager<UserEntity>>();
            var roleManager = Database.GetService<RoleManager<IdentityRole>>();
            var roleConfig = new RoleConfiguration();
            var userConfig = new UserConfiguration();
            
            var types = Enum.GetNames(typeof(UserClaimEnum));
            var claims = new List<Claim>();

            
                claims.AddRange(types.Select(t => new Claim("PooperClaim", t)));

                builder.ApplyConfiguration(roleConfig);
            builder.ApplyConfiguration(userConfig);
            
            var adminRoleId = roleConfig.Roles.First(r => r.Name == UserRolesEnum.Administrator.ToString()).Id;
            var pooperRoleId = roleConfig.Roles.First(r => r.Name == UserRolesEnum.Pooper.ToString()).Id;
            var userRoleDictionary = new Dictionary<string, string>();
            
            foreach (var userEntity in userConfig.Users)
            {
                if (userEntity.UserName.Contains("Balkar"))
                {
                    userRoleDictionary.Add(userEntity.Id, adminRoleId);
                    continue;
                }
                else if (userEntity.UserName != null) userRoleDictionary.Add(userEntity.Id, pooperRoleId);

                userManager.AddClaimsAsync(userEntity, claims);

            }

            var userRoleConfig = new UserRoleConfiguration(userRoleDictionary);
            builder.ApplyConfiguration(userRoleConfig);

            base.OnModelCreating(builder);
        }
    }
}

using System.Security.Claims;
using Core.Auh.Entities;
using Core.Auh.Enums;
using Core.Base.DataBase.Entities;
using IdentityDb.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.IdentityDb
{
    public class ApplicationContext : IdentityDbContext<
        UserEntity,
        IdentityRole<string>,
        string,
        IdentityUserClaim<string>,
        IdentityUserRole<string>,
        IdentityUserLogin<string>,
        IdentityRoleClaim<string>,
        IdentityUserToken<string>>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            // Database.EnsureCreated();
        }
        
        public DbSet<PooperEntity> Poopers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //todo:  decompose logic from user to pooper
            builder.Entity<PooperEntity>().ToTable("Poopers");
            builder.Entity<PooperEntity>().HasOne<UserEntity>();
            
            var roleConfig = new RoleConfiguration();
            var userConfig = new UserConfiguration();
            
            var types = Enum.GetNames(typeof(UserClaimEnum));
            
            var claims = new List<Claim>();
            claims.AddRange(types.Select(t => new Claim(UserClaimTypeEnum.PoopClaim.ToString(), t)));
        
            builder.ApplyConfiguration(roleConfig);
            builder.ApplyConfiguration(userConfig);
            
            var adminRoleId = roleConfig.Roles.First(r => r.Name == UserRolesEnum.Administrator.ToString()).Id;
            var pooperRoleId = roleConfig.Roles.First(r => r.Name == UserRolesEnum.Pooper.ToString()).Id;
            var userRoleDictionary = new Dictionary<string, string>();
            var userClaimsDictionary = new Dictionary<UserEntity, List<Claim>>();
            
            foreach (var userEntity in userConfig.Users)
            {
                if (userEntity.UserName.Contains("Balkar"))
                {
                    userEntity.RoleId = adminRoleId;
                    userRoleDictionary.Add(userEntity.Id, adminRoleId);
                    continue;
                }
                else if (userEntity.UserName != null)
                {
                    userEntity.RoleId = pooperRoleId;
                    userRoleDictionary.Add(userEntity.Id, pooperRoleId);
                    userClaimsDictionary.Add(userEntity, claims);
                }
            }
            
            
            var userRoleConfig = new UserRoleConfiguration(userRoleDictionary);
            builder.ApplyConfiguration(userRoleConfig);
        
            List<IdentityUserClaim<string>> claimEntities = new List<IdentityUserClaim<string>>();
            foreach (var keyValuePair in userClaimsDictionary)
            {
                foreach (var claim in keyValuePair.Value)
                {
                    var user = keyValuePair.Key;
                    claimEntities.Add(new IdentityUserClaim<string>()
                    {
                        Id = Math.Abs(String.GetHashCode(claim.Value + keyValuePair.Key)),
                        UserId = user.Id,
                        ClaimType = UserClaimTypeEnum.PoopClaim.ToString(),
                        ClaimValue = claim.Value
                    });
                }
            }
        
            builder.Entity<IdentityUserClaim<string>>().Property(p => p.UserId).IsRequired();
            builder.Entity<IdentityUserClaim<string>>().HasOne<UserEntity>()
                .WithMany(u => u.Claims)
                .HasForeignKey(c => c.UserId)
                .HasPrincipalKey(cl => cl.Id);
            
            builder.Entity<IdentityUserClaim<string>>().HasData(claimEntities);
            base.OnModelCreating(builder);
        }
    }
}

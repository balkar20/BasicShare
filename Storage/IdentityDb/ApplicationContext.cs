using System.Security.Claims;
using Core.Auh.Entities;
using Core.Auh.Enums;
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
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.Entity<PooperEntity>().ToTable("Poopers");
            // builder.Entity<PooperEntity>().HasOne<UserEntity>();

            var roleConfig = new RoleConfiguration();
            var userConfig = new UserConfiguration();
            
            
            var types = Enum.GetNames(typeof(UserClaimEnum));

            var userClaims = new List<Claim>();
            userClaims.AddRange(types.Select(t => new Claim(UserClaimTypeEnum.SharerClaim.ToString(), t)));

            var adminClaims = new List<Claim>();
            adminClaims.Add(new Claim(UserClaimTypeEnum.BossClaim.ToString(), UserClaimTypeEnum.BossClaim.ToString()));
            
            builder.ApplyConfiguration(roleConfig);
            builder.ApplyConfiguration(userConfig);

            var adminRoleId = roleConfig.Roles.First(r => r.Name == UserRolesEnum.Administrator.ToString()).Id;
            var userEntityRoleId = roleConfig.Roles.First(r => r.Name == UserRolesEnum.Pooper.ToString()).Id;

            var (userClaimsDictionary, userRoleDictionary) = CreateRoleClaimDictionaries(userConfig, adminRoleId, adminClaims, userEntityRoleId, userClaims);
            
            var userRoleConfig = new UserRoleConfiguration(userRoleDictionary);
            builder.ApplyConfiguration(userRoleConfig);

            var userClaimConfig = new UserClaimConfiguration(userClaimsDictionary);
            builder.ApplyConfiguration(userClaimConfig);
        }
        
        private static (Dictionary<UserEntity, List<Claim>>, Dictionary<string, string> userRoleDictionary) CreateRoleClaimDictionaries(UserConfiguration userConfig, string adminRoleId, List<Claim> adminClaims, string userEntityRoleId, List<Claim> userClaims)
        {
            Dictionary<UserEntity, List<Claim>> userClaimsDictionary = new();
            Dictionary<string, string> userRoleDictionary = new();
            foreach (var userEntity in userConfig.Users)
            {
                if (userEntity.UserName.Contains("Balkar"))
                {
                    userEntity.RoleId = adminRoleId;
                    userRoleDictionary.Add(userEntity.Id, adminRoleId);
                    userClaimsDictionary.Add(userEntity, adminClaims);
                    continue;
                }

                userEntity.RoleId = userEntityRoleId;
                userRoleDictionary.Add(userEntity.Id, userEntityRoleId);

                Random rand = new Random();
                List<Claim> randomClaims = userClaims.OrderBy(x => rand.Next()).Take(rand.Next(1, userClaims.Count)).ToList();
                userClaimsDictionary.Add(userEntity, randomClaims);
            }

            return (userClaimsDictionary, userRoleDictionary);
        }
    }
}
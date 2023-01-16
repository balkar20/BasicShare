using Data.IdentityDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Core.Auh.Entities;

namespace IdentityDb
{
    public class SeedDataService
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            ApplicationContext context;
            UserManager<UserEntity> _userManager;
            using (var scope = serviceProvider.CreateScope())
            {
                context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                _userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();

                //var context = serviceProvider.GetRequiredService<ApplicationContext>();

                //string[] roles = new string[] { "Owner", "Administrator", "Manager", "Editor", "Buyer", "Business", "Seller", "Subscriber" };

                //foreach (string role in roles)
                //{
                //    var roleStore = new RoleStore<IdentityRole>(context);

                //    if (!context.Roles.Any(r => r.Name == role))
                //    {
                //        roleStore.CreateAsync(new IdentityRole(role));
                //    }
                //}
                var roleStore = new RoleStore<IdentityRole>(context);
                var allRoles = roleStore.Roles;

                var user = new UserEntity
                {
                    UserName = "admin",
                    Email = "balkar20@mail.ru",
                    NormalizedEmail = "balkar20@mail.ru",
                    NormalizedUserName = "admin",
                    PhoneNumber = "+79111761331",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };


                //if (!context.Users.Any(u => u.UserName == user.UserName))
                //{
                //    var password = new PasswordHasher<UserEntity>();
                //    var hashed = password.HashPassword(user, "12121Qer_");
                //    user.PasswordHash = hashed;

                //    var userStore = new UserStore<UserEntity>(context);
                    
                //    var result = _userManager.CreateAsync(user);

                //}

                //AssignRoles(serviceProvider, user.Email, new[] { "ADMINISTRATOR" } );

                //context.SaveChangesAsync();
            }
        }

        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            UserManager<UserEntity> _userManager = services.GetService<UserManager<UserEntity>>();
            UserEntity user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }
    }
}

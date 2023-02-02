using Data.IdentityDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Core.Auh.Entities;
using Core.Base.DataBase.Entities;

namespace IdentityDb
{
    public class SeedDataService
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            var poppNames = new List<string>()
            {
                //1. Nastya todo - order
                "VladBalkar",
                "VladBlack",
                "NastyaKareva",
                "NastyaBocharnikova",
                "SanchoLeaver",
                
            };
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
            }

            var roleStore = new RoleStore<IdentityRole>(context);
                var allRoles = roleStore.Roles;

                // var user = new UserEntity
                // {
                //     UserName = "admin",
                //     Email = "balkar20@mail.ru",
                //     NormalizedEmail = "balkar20@mail.ru",
                //     NormalizedUserName = "admin",
                //     PhoneNumber = "+79111761331",
                //     EmailConfirmed = true,
                //     PhoneNumberConfirmed = true,
                //     SecurityStamp = Guid.NewGuid().ToString("D")
                // };

                // List<>
                await CreatePoopers(serviceProvider, context, poppNames);
                await context.SaveChangesAsync();
            }


            public static async Task<IdentityResult> AssignRoles(IServiceProvider services,  ApplicationContext context, string email, string[] roles)
        {
            UserManager<UserEntity> _userManager = services.GetService<UserManager<UserEntity>>();
            UserEntity user = await _userManager.FindByEmailAsync(email);
            return await _userManager.AddToRolesAsync(user, roles);
        }

        public static async Task CreatePoopers(IServiceProvider serviceProvider,
            ApplicationContext context, List<string> poppNames)
        {
            UserManager<UserEntity> _userManager = serviceProvider.GetService<UserManager<UserEntity>>();
            var roleStore = new RoleStore<IdentityRole>(context);
            var allRoles = roleStore.Roles;
            foreach (var poppName in poppNames)
            {
                var pooper = new UserEntity
                {
                    UserName = poppName,
                    Email = $"{poppName}20@mail.ru",
                    NormalizedEmail = $"{poppName}20@mail.ru",
                    NormalizedUserName = poppName,
                    // todo sms to number
                    PhoneNumber = "",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                var password = new PasswordHasher<UserEntity>();
                var hashed = password.HashPassword(pooper, "12121Qer_");
                pooper.PasswordHash = hashed;

                var userStore = new UserStore<UserEntity>(context);

                var result = await _userManager.CreateAsync(pooper);

                if (pooper.UserName.Contains("Balkar"))
                {
                    await AssignRoles(serviceProvider, context, pooper.Email, new[] { "ADMINISTRATOR" });
                    continue;
                }

                await AssignRoles(serviceProvider, context, pooper.Email, new[] { "pooper" });
            }
        }
        
    }
}

using Core.Auh.Entities;
using Core.Auh.Enums;
using IdentityDb.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

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
            var roleId = roleConfig.Roles.FirstOrDefault(r => r.Name == UserRolesEnum.Administrator.ToString()).Id;
            var userId = userConfig.Users.FirstOrDefault(u => u.UserName == "admin").Id;
            Console.WriteLine($"roleId : {roleId}");
            Console.WriteLine($"userId : {userId}");
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });

            base.OnModelCreating(builder);
        }
    }
}

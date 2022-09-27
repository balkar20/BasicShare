using Core.Auh.Entities;
using Core.Auh.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public List<UserEntity> Users { get; set; }
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {

            var email = "balkar20@mail.ru";
            var userName = "admin";
            var user = new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userName,
                Email = email,
                NormalizedEmail = email.ToUpper(),
                NormalizedUserName = userName.ToUpper(),
                PhoneNumber = "+79111761331",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            //user.Id = Guid.NewGuid().ToString();

            Users = new() { user };

            var password = new PasswordHasher<UserEntity>();
            var hashed = password.HashPassword(user, "12121Qer_");
            user.PasswordHash = hashed;

            builder.HasData(user);
        }
    }
}

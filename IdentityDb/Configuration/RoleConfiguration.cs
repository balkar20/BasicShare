using Core.Auh.Entities;
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

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            string ADMIN_ID = "02174cf0–9412–4cfe - afbf - 59f706d72cf6";
            string ROLE_ID = "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6";

            Roles = new List<IdentityRole>(){
                new IdentityRole
                {
                    Id = ROLE_ID,
                    Name = "Viewer",
                    NormalizedName = "VIEWER"
                },
                new IdentityRole
                {
                    Id = ADMIN_ID,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }};


            builder.HasData(Roles);
        }
    }

    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public List<UserEntity> Users { get; set; }
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            
            var user = new UserEntity
            {
                Id = 1,
                UserName = "admin",
                Email = "balkar20@mail.ru",
                NormalizedEmail = "balkar20@mail.ru",
                NormalizedUserName = "admin",
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

using Core.Auh.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityDb.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        private readonly List<string> poppNames = new List<string>()
        {
            //1. Nastya todo - order
            "VladBalkar",
            "VladBlack",
            "NastyaKareva",
            "NastyaBocharnikova",
            "AdrewRojer",
            "SanchoLeaver"
        };

        public List<UserEntity> Users { get; set; } = new List<UserEntity>();
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {

            // var email = "balkar20@mail.ru";
            // var userName = "admin";
            // var user = new UserEntity
            // {
            //     Id = Guid.NewGuid().ToString(),
            //     UserName = userName,
            //     Email = email,
            //     NormalizedEmail = email.ToUpper(),
            //     NormalizedUserName = userName.ToUpper(),
            //     PhoneNumber = "+79111761331",
            //     EmailConfirmed = true,
            //     PhoneNumberConfirmed = true,
            //     SecurityStamp = Guid.NewGuid().ToString("D")
            // };
            
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
                var hashed = password.HashPassword(pooper, "default");
                pooper.PasswordHash = hashed;

                builder.HasData(pooper);
                Users.Add(pooper);
            }

            //user.Id = Guid.NewGuid().ToString();

            // var password = new PasswordHasher<UserEntity>();
            // var hashed = password.HashPassword(user, "12121Qer_");
            // user.PasswordHash = hashed;
            // builder.HasData(user);
        }
    }
}

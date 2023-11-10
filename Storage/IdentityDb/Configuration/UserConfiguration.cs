using Core.Auh.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityDb.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        private readonly List<string> userNames = new List<string>()
        {
            //1. Nastya todo - order
            "VladBlack",
            "NastyaKareva",
            "NastyaBocharnikova",
            "AdrewRojer",
            "SanchoLeaver",
            "GregorPiha",
        };

        public List<UserEntity> Users { get; set; } = new ();
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
                        
            builder.HasMany(e => e.UserRoles)
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            for (int i = 0; i < 30; i++)
            {
                Random rand = new Random();
                var randomName = $"{userNames[rand.Next(userNames.Count)]}-{i}";
                
                var user = new UserEntity
                {
                    UserName = randomName,
                    Email = $"{randomName}20@mail.ru",
                    NormalizedEmail = $"{randomName}20@mail.ru".ToUpper(),
                    NormalizedUserName = randomName.ToUpper(),
                    // todo sms to number
                    PhoneNumber = "",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    Description = "I am a pooper! Poo poo poo!!!",
                };

                var password = new PasswordHasher<UserEntity>();
                var hashed = password.HashPassword(user, "default");
                user.PasswordHash = hashed;

                // Each User can have many UserClaims
                // builder.HasMany(e => e.Claims)
                //     .WithOne()
                //     .HasForeignKey(uc => uc.UserId)
                //     .IsRequired();

                builder.HasData(user);
                Users.Add(user);
            }
            
            var admin = new UserEntity
            {
                UserName = $"VladBalkar",
                Email = $"VladBalkar20@mail.ru",
                NormalizedEmail = $"VladBalkar20@mail.ru".ToUpper(),
                NormalizedUserName = "VladBalkar".ToUpper(),
                // todo sms to number
                PhoneNumber = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Description = "I am the admin! Call me the Boss!!!",
            };

            var adminPassword = new PasswordHasher<UserEntity>();
            var hashedAdminPassword = adminPassword.HashPassword(admin, "default");
            admin.PasswordHash = hashedAdminPassword;
            builder.HasData(admin);
            Users.Add(admin);
        }
    }
}

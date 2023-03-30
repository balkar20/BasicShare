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
            "SanchoLeaver",
            "GregorPiha",
        };

        public List<UserEntity> Users { get; set; } = new List<UserEntity>();
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            foreach (var poppName in poppNames)
            {
                var pooper = new UserEntity
                {
                    UserName = poppName,
                    Email = $"{poppName}20@mail.ru",
                    NormalizedEmail = $"{poppName}20@mail.ru".ToUpper(),
                    NormalizedUserName = poppName.ToUpper(),
                    // todo sms to number
                    PhoneNumber = "",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    Description = "I am a pooper! Poo poo poo!!!",
                };

                var password = new PasswordHasher<UserEntity>();
                var hashed = password.HashPassword(pooper, "default");
                pooper.PasswordHash = hashed;

                // Each User can have many UserClaims
                builder.HasMany(e => e.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                builder.HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                builder.HasMany(e => e.Tokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                builder.HasData(pooper);
                Users.Add(pooper);
            }
        }
    }
}

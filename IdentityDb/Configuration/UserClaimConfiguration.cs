using System.Security.Claims;
using Core.Auh.Entities;
using Core.Auh.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityDb.Configuration;

internal class UserClaimConfiguration : IEntityTypeConfiguration<ClaimEntity>
{
    //public List<IdentityUserRole> Users { get; set; }
    // private Dictionary<string, List<Claim>> UserClaimDictionary;
    private List<ClaimEntity> identityUserClaims;
    private List<int> randomList = new List<int>();
    private Random Random = new Random();

    public UserClaimConfiguration(Dictionary<UserEntity, List<Claim>> userClaimDictionary)
    {
        identityUserClaims = new List<ClaimEntity>();

        foreach (var keyValuePair in userClaimDictionary)
        {
            foreach (var claim in keyValuePair.Value)
            {
                UserClaimEnum userClaimEnum  = (UserClaimEnum)Enum.Parse(typeof(UserClaimEnum), claim.Value);
                identityUserClaims.Add(new ClaimEntity()
                {
                    UserId = keyValuePair.Key.Id,
                    ClaimType = claim.Type,
                    ClaimValue = claim.Value,
                    Id = Math.Abs(String.GetHashCode(claim.Value + keyValuePair.Key)),
                    // User = keyValuePair.Key
                });
            }
        }
    }

    public void Configure(EntityTypeBuilder<ClaimEntity> builder)
    {
        // builder.HasKey(u => u.Id);
        // builder.HasOne<UserEntity>(u => u.User)
        //     .WithMany(e => e.Claims)
        //     .HasForeignKey(k => k.UserId);
        foreach (var userClaim in identityUserClaims)
        {
            // if (string.IsNullOrWhiteSpace(userClaim.Id.ToString()))
            // {
            //     throw new NullReferenceException();
            // }
            // Console.WriteLine(userClaim.User.UserName);
            // if (userClaim.Id >= 0)
            // {
            //     Console.WriteLine($"Fuck Fuck Fuck Fuck: {userClaim.Id}");
            // }
            // if (string.IsNullOrWhiteSpace(userClaim.User.Id))
            // {
            //     Console.WriteLine($"Fuck Fuck Fuck Fuck: {userClaim.User.Id}");
            // }
            // Console.WriteLine(userClaim.Id);
            // Console.WriteLine(userClaim.User.Id);
        }
        builder.HasData(identityUserClaims);
    }
}
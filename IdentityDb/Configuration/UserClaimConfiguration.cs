using System.Security.Claims;
using Core.Auh.Entities;
using Core.Auh.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityDb.Configuration;

internal class UserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
{
    //public List<IdentityUserRole> Users { get; set; }
    // private Dictionary<string, List<Claim>> UserClaimDictionary;
    private List<IdentityUserClaim<string>> identityUserClaims;
    private List<int> randomList = new List<int>();
    private Random Random = new Random();

    public UserClaimConfiguration(Dictionary<string, List<Claim>> userClaimDictionary)
    {
        identityUserClaims = new List<IdentityUserClaim<string>>();

        foreach (var keyValuePair in userClaimDictionary)
        {
            foreach (var claim in keyValuePair.Value)
            {
                UserClaimEnum userClaimEnum  = (UserClaimEnum)Enum.Parse(typeof(UserClaimEnum), claim.Value);
                identityUserClaims.Add(new IdentityUserClaim<string>()
                {
                    UserId = keyValuePair.Key,
                    ClaimType = claim.Type,
                    ClaimValue = claim.Value,
                    Id = String.GetHashCode(claim.Value + keyValuePair.Key)
                });
            }
        }
    }

    public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
    {
        // builder.HasMany<UserEntity>().WithMany(u => u.Claims);
        builder.HasData(identityUserClaims);
    }
}
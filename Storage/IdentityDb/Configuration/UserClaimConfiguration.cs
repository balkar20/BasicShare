using System.Security.Claims;
using Core.Auh.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityDb.Configuration;

internal class UserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
{
    private List<ClaimEntity> identityUserClaims;

    private Dictionary<UserEntity, List<Claim>> UserClaimDictionary;

    public UserClaimConfiguration(Dictionary<UserEntity, List<Claim>> userClaimDictionary)
    {
        UserClaimDictionary = userClaimDictionary;
    }

    public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasOne<UserEntity>()
            .WithMany(e => e.Claims)
            .HasForeignKey(k => k.UserId);

        var userClaims = CreateClaimEntities();
        builder.HasData(userClaims);
    }
    
    private List<IdentityUserClaim<string>> CreateClaimEntities()
    {
        List<IdentityUserClaim<string>> claimEntities = new List<IdentityUserClaim<string>>();
        foreach (var keyValuePair in UserClaimDictionary)
        {
            foreach (var claim in keyValuePair.Value)
            {
                var user = keyValuePair.Key;
                claimEntities.Add(new IdentityUserClaim<string>()
                {
                    Id = Math.Abs(String.GetHashCode(claim.Value + keyValuePair.Key)),
                    UserId = user.Id,
                    ClaimType = claim.Type,
                    ClaimValue = claim.Value
                });
            }
        }

        return claimEntities;
    }
}
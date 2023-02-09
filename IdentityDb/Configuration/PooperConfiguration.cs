using Core.Base.DataBase.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityDb.Configuration
{
    internal class PooperConfiguration : IEntityTypeConfiguration<PooperEntity>
    {
        //public List<IdentityUserRole> Users { get; set; }
        private Dictionary<string, string> UserRoleDictionary;
        private List<PooperEntity> PooperList;

        public PooperConfiguration(List<string> userIds)
        {
            PooperList = userIds.Select(d => new PooperEntity {
                UserId = d,
                Description = "I am a pooper! Poo poo poo!",
                AmountOfPoops = 10
            }).ToList();
        }

        public void Configure(EntityTypeBuilder<PooperEntity> builder)
        {
            builder.HasData(PooperList);
        }
    }
}

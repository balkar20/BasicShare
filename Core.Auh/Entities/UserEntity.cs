using Core.Base.DataBase.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Core.Auh.Entities
{
    public class UserEntity : IdentityUser
    {
        // public long Id { get; set; }
        public int? Year { get; set; }
        
        public int AmountOfPoops { get; set; }
        
        public string? Description { get; set; }

        public IQueryable<IdentityUserClaim<string>> Claims { get; set; }

        public IQueryable<IdentityUserRole<string>> Roles { get; set; }
        //
        // public List<IdentityUserRole<string>>? Roles { get; set; }
    }
}

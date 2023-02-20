using Core.Base.DataBase.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Core.Auh.Entities
{
    public class UserEntity : IdentityUser
    {
        public override string Id { get; set; }

        public int? Year { get; set; }
        
        public int AmountOfPoops { get; set; }
        
        public string RoleId { get; set; }
        
        public string? Description { get; set; }

        public string? Image { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }

        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }
    }
}

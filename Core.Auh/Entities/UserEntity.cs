using Microsoft.AspNetCore.Identity;

namespace Core.Auh.Entities
{
    public class UserEntity : IdentityUser
    {
        public override string Id { get; set; }

        public int? Year { get; set; }
        
        public int AmountOfPoints { get; set; }
        
        public string RoleId { get; set; }
        
        public string? Description { get; set; }

        public string? Image { get; set; }

        
        public virtual List<IdentityUserLogin<string>> Logins { get; set; }
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        
        public virtual List<IdentityUserToken<string>> Tokens { get; set; }

        public virtual List<IdentityUserRole<string>> UserRoles { get; set; }
    }
}

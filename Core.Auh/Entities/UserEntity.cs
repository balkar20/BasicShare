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

        public List<IdentityUserClaim<string>>? Claims { get; set; }
        
        public List<IdentityUserLogin<string>>? Logins { get; set; }
        
        public List<IdentityUserToken<string>>? Tokens { get; set; }

        public List<IdentityUserRole<string>>? UserRoles { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace Core.Auh.Entities
{
    public class UserEntity : IdentityUser
    {
        public int? Year { get; set; }
    }
}

using Core.Base.DataBase.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Core.Auh.Entities
{
    public class UserEntity : IdentityUser
    {
        // public long Id { get; set; }
        public int? Year { get; set; }
    }
}

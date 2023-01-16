using Core.Auh.Enums;

namespace Mod.Auth.Models
{
    public record RegisterModel(string Email, string UserName, string Password, string? PhoneNumber, string? Male, int? Year, UserRolesEnum? UserRole)
    {
        //public string Email { get; set; }
        //public string Password { get; set; }
        //public string? PhoneNumber { get; set; }
        //public string? Male { get; set; }
        //public int? Year { get; set; }
    }
}

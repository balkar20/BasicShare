using IdentityProvider.Shared.Interfaces;

namespace IdentityProvider.Shared;

public record RegisterViewModel: IViewModel
{
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string ConfirmPassword { get; set; }
    
    public string UserName { get; set; }
    
    public string PhoneNumber { get; set; }

    public int Year { get; set; }

    public UserRolesEnum UserRole { get; set; }
}

public enum UserRolesEnum
{
    Administrator,
    Viewer,
    Pooper,
    Reviwer,
    Maker,
}
using IdentityProvider.Shared.Interfaces;

namespace IdentityProvider.Shared;

public record LoginViewModel: IViewModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}
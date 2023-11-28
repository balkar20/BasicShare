using IdentityProvider.Shared.Interfaces;

namespace IdentityProvider.Shared;

public record LoginResponseViewModel: IViewModel
{
    public string? Token { get; init; }
}
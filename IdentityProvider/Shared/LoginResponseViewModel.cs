using IdentityProvider.Shared.Interfaces;

namespace IdentityProvider.Shared;

public record LoginResponseViewModel: IViewModel
{
    public bool IsAuthSuccessful { get; init; }
    public string? ErrorMessage { get; init; }
    public string? Token { get; init; }
}
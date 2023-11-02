using IdentityProvider.Shared;

namespace ClientLibrary.Interfaces.Particular;

public interface IClientOrderCreationService
{
    Task<CreateOrderReply> CreateOrder();
}
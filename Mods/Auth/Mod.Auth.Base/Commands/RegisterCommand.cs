using Core.Transfer;
using MediatR;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Commands
{
    public record RegisterCommand(RegisterViewModel RegisterViewModel) : IRequest<ResponseResultWithData<RegisterResponseModel>>;
}

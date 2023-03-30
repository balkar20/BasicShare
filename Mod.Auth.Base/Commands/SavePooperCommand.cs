using MediatR;
using Mod.Auth.Models;
using Core.Transfer;

namespace Mod.Auth.Base.Commands
{
    public record SavePooperCommand(PooperModel PooperModel) : IRequest<BaseResponseResult>;
}

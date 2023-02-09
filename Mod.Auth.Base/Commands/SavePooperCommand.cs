using MediatR;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Commands
{
    public record SavePooperCommand(PooperModel PooperModel) : IRequest<PooperSaveResponseModel>;
}

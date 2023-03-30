using MediatR;
using Mod.Pooper.Models;

namespace Mod.Pooper.Base.Commands;

public record CreatePooperCommand(PooperModel Pooper) : IRequest<PooperModel>;
using MediatR;
using Mod.Pooper.Models;

namespace Mod.Pooper.Base.Commands;

public record UpdatePooperCommand(PooperModel Pooper) : IRequest<PooperModel>;
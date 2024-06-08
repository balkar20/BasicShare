// using MediatR;

using MediatR;

namespace Mod.PowerSupply.Base.Queries;

public record GetTempQuery : IRequest<string>;
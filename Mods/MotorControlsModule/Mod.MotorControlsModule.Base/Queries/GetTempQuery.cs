// using MediatR;

using MediatR;

namespace Mod.MotorControlsModule.Base.Queries;

public record GetTempQuery : IRequest<string>;
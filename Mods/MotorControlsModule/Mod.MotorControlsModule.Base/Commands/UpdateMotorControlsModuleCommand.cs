using Core.Transfer;
using MediatR;
using Mod.MotorControlsModule.Models;

namespace Mod.MotorControlsModule.Base.Commands;

public record UpdateMotorControlsModuleCommand(MotorControlsModuleModel MotorControlsModule) : IRequest<BaseResponseResult>;
using Core.Transfer;
using MediatR;
using Mod.MotorControlsModule.Models;

namespace Mod.MotorControlsModule.Base.Commands;

public record CreateMotorControlsModuleCommand(MotorControlsModuleModel MotorControlsModule) : IRequest<BaseResponseResult>;
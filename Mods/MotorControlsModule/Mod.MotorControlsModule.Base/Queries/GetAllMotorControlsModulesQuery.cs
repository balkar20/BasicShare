// using MediatR;

using Core.Base.Output;
using Core.Transfer;
using MediatR;
using Mod.MotorControlsModule.Base.ViewModels;
using Mod.MotorControlsModule.Models;

namespace Mod.MotorControlsModule.Base.Queries;

public record GetAllMotorControlsModulesQuery : IRequest<ResponseResultWithData<List<MotorControlsModuleModel>>>;
// using MediatR;

using Core.Base.Output;
using Core.Transfer;
using MediatR;
using Mod.CameraModule.Base.ViewModels;
using Mod.CameraModule.Models;

namespace Mod.CameraModule.Base.Queries;

public record GetAllCameraModulesQuery : IRequest<ResponseResultWithData<List<CameraModuleModel>>>;
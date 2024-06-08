using Core.Transfer;
using MediatR;
using Mod.CameraModule.Models;

namespace Mod.CameraModule.Base.Commands;

public record CreateCameraModuleCommand(CameraModuleModel CameraModule) : IRequest<BaseResponseResult>;
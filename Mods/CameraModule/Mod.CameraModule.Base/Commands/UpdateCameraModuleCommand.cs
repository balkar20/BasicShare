using Core.Transfer;
using MediatR;
using Mod.CameraModule.Models;

namespace Mod.CameraModule.Base.Commands;

public record UpdateCameraModuleCommand(CameraModuleModel CameraModule) : IRequest<BaseResponseResult>;
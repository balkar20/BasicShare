using Mod.CameraModule.Models;

namespace Mod.CameraModule.Interfaces;

public interface ICameraModuleService
{
    Task<List<CameraModuleModel>> GetAllCameraModules();
    Task<CameraModuleModel> UpdateCameraModule(CameraModuleModel product);
    Task<CameraModuleModel> CreateAsync(CameraModuleModel requestCameraModule);
}
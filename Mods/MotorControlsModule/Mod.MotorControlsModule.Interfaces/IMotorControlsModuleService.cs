using Mod.MotorControlsModule.Models;

namespace Mod.MotorControlsModule.Interfaces;

public interface IMotorControlsModuleService
{
    Task<List<MotorControlsModuleModel>> GetAllMotorControlsModules();
    Task<MotorControlsModuleModel> UpdateMotorControlsModule(MotorControlsModuleModel product);
    Task<MotorControlsModuleModel> CreateAsync(MotorControlsModuleModel requestMotorControlsModule);
}
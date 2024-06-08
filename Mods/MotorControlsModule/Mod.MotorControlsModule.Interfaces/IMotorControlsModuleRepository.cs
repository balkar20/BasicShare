using Core.Base.DataBase.Entities;
using Infrastructure.Interfaces;
using Mod.MotorControlsModule.Models;

namespace Mod.MotorControlsModule.Interfaces;

public interface IMotorControlsModuleRepository: IRepository<MotorControlsModuleEntity, MotorControlsModuleModel>
{
    
}
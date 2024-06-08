using Core.Base.DataBase.Entities;
using Infrastructure.Interfaces;
using Mod.CameraModule.Models;

namespace Mod.CameraModule.Interfaces;

public interface ICameraModuleRepository: IRepository<CameraModuleEntity, CameraModuleModel>
{
    
}
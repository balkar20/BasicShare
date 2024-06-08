using AutoMapper;
using Core.Base.DataBase.Entities;
using Mod.MotorControlsModule.Models;

namespace Mod.MotorControlsModule.Base.Mapping;

public class MotorControlsModuleModelProfile: Profile
{
    public MotorControlsModuleModelProfile()
    {
        CreateMap<MotorControlsModuleModel, MotorControlsModuleEntity>()
            .ReverseMap();
    }
}
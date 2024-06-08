using AutoMapper;
using Mod.MotorControlsModule.Base.ViewModels;
using Mod.MotorControlsModule.Models;

namespace Mod.MotorControlsModule.Base.Mapping;

public class MotorControlsModuleViewModelProfile: Profile
{
    public MotorControlsModuleViewModelProfile()
    {
        CreateMap<MotorControlsModuleModel, MotorControlsModuleViewModel>().ReverseMap();
    }
}
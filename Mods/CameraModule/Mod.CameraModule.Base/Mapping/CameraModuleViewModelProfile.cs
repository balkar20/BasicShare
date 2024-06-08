using AutoMapper;
using Mod.CameraModule.Base.ViewModels;
using Mod.CameraModule.Models;

namespace Mod.CameraModule.Base.Mapping;

public class CameraModuleViewModelProfile: Profile
{
    public CameraModuleViewModelProfile()
    {
        CreateMap<CameraModuleModel, CameraModuleViewModel>().ReverseMap();
    }
}
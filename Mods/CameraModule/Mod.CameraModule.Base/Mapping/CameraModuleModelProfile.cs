using AutoMapper;
using Core.Base.DataBase.Entities;
using Mod.CameraModule.Models;

namespace Mod.CameraModule.Base.Mapping;

public class CameraModuleModelProfile: Profile
{
    public CameraModuleModelProfile()
    {
        CreateMap<CameraModuleModel, CameraModuleEntity>()
            .ReverseMap();
    }
}
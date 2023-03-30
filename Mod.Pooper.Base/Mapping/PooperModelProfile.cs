using AutoMapper;
using Core.Base.DataBase.Entities;
using Mod.Pooper.Models;

namespace Mod.Pooper.Base.Mapping;

public class PooperModelProfile: Profile
{
    public PooperModelProfile()
    {
        CreateMap<PooperModel, PooperEntity>().ReverseMap();
    }
}
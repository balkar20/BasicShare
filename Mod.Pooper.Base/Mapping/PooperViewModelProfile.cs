using AutoMapper;
using Mod.Pooper.Base.ViewModels;
using Mod.Pooper.Models;

namespace Mod.Pooper.Base.Mapping;

public class PooperViewModelProfile: Profile
{
    public PooperViewModelProfile()
    {
        CreateMap<PooperModel, PooperViewModel>().ReverseMap();
    }
}
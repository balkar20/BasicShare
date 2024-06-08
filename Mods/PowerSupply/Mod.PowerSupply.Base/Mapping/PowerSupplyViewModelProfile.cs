using AutoMapper;
using Mod.PowerSupply.Base.ViewModels;
using Mod.PowerSupply.Models;

namespace Mod.PowerSupply.Base.Mapping;

public class PowerSupplyViewModelProfile: Profile
{
    public PowerSupplyViewModelProfile()
    {
        CreateMap<PowerSupplyModel, PowerSupplyViewModel>().ReverseMap();
    }
}
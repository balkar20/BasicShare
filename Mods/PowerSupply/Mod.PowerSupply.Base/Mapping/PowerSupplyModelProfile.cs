using AutoMapper;
using Core.Base.DataBase.Entities;
using Mod.PowerSupply.Models;

namespace Mod.PowerSupply.Base.Mapping;

public class PowerSupplyModelProfile: Profile
{
    public PowerSupplyModelProfile()
    {
        CreateMap<PowerSupplyModel, PowerSupplyEntity>()
            .ReverseMap();
    }
}
using AutoMapper;
using Core.Base.DataBase.Entities;
using Mod.WareHouseProduct.Models;

namespace Mod.WareHouseProduct.Base.Mapping;

public class WareHouseProductModelProfile: Profile
{
    public WareHouseProductModelProfile()
    {
        CreateMap<WareHouseProductModel, WareHouseProductEntity>().ReverseMap();
    }
}
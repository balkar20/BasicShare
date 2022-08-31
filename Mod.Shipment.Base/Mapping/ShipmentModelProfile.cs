using AutoMapper;
using Core.Base.DataBase.Entities;
using Mod.Shipment.Models;

namespace Mod.Shipment.Base.Mapping;

public class ShipmentModelProfile: Profile
{
    public ShipmentModelProfile()
    {
        CreateMap<ShipmentModel, ShipmentEntity>().ReverseMap();
    }
}
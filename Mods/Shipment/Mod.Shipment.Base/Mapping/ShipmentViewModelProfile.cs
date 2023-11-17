using AutoMapper;
using Mod.Shipment.Base.ViewModels;
using Mod.Shipment.Models;

namespace Mod.Shipment.Base.Mapping;

public class ShipmentViewModelProfile: Profile
{
    public ShipmentViewModelProfile()
    {
        CreateMap<ShipmentModel, ShipmentViewModel>().ReverseMap();
    }
}
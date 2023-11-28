using Core.Base.DataBase.Entities;
using Infrastructure.Interfaces;
using Mod.Shipment.Models;

namespace Mod.Shipment.Interfaces;

public interface IShipmentRepository: IRepository<ShipmentEntity, ShipmentModel>
{
    
}
using Mod.Shipment.Models;

namespace Mod.Shipment.Interfaces;

public interface IShipmentService
{
    Task<List<ShipmentModel>> GetAllShipments();
}
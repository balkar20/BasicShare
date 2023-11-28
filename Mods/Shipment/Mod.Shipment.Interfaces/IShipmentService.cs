using Mod.Shipment.Models;

namespace Mod.Shipment.Interfaces;

public interface IShipmentService
{
    Task<List<ShipmentModel>> GetAllShipments();
    Task<ShipmentModel> UpdateShipment(ShipmentModel product);
    Task<ShipmentModel> CreateAsync(ShipmentModel requestShipment);
}
using Mod.PowerSupply.Models;

namespace Mod.PowerSupply.Interfaces;

public interface IPowerSupplyService
{
    Task<List<PowerSupplyModel>> GetAllPowerSupplys();
    Task<PowerSupplyModel> UpdatePowerSupply(PowerSupplyModel product);
    Task<PowerSupplyModel> CreateAsync(PowerSupplyModel requestPowerSupply);
}
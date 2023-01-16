using Mod.WareHouseProduct.Models;

namespace Mod.WareHouseProduct.Interfaces;

public interface IWareHouseProductService
{
    Task<List<WareHouseProductModel>> GetAllWareHouseProducts();
}
using Core.Base.DataBase.Entities;
using Infrastructure.Interfaces;
using Mod.WareHouseProduct.Models;

namespace Mod.WareHouseProduct.Interfaces;

public interface IWareHouseProductRepository: IRepository<WareHouseProductEntity, WareHouseProductModel>
{
}
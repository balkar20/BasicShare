using Core.Base.DataBase.Entities;
using Infrastructure.Interfaces;
using ModProduct.Models;

namespace Mod.Product.Interfaces;

public interface IProductRepository: IRepository<ProductEntity, ProductModel>
{
}
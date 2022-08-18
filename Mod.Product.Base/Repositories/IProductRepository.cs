using Core.Base.DataBase.Entities;
using Infrastructure.Interfaces;
using Mod.Product.Base.Models;

namespace Mod.Product.Base.Repositories;

public interface IProductRepository: IRepository<ProductEntity, ProductModel>
{
    
}
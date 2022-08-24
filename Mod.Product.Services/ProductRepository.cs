


using AutoMapper;
using Core.Base.DataBase.Entities;
using Db;
using Mod.Product.Interfaces;
using ModProduct.Models;

namespace Mod.Product.Base.Repositories;

public class ProductRepository: GenericRepository<ProductEntity, ProductModel>, IProductRepository
{
    public ProductRepository(ApiDbContext apiDbContext, IMapper mapper): base(apiDbContext, mapper)
    {
    }
}


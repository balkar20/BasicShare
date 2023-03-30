using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Data.Db;
using Infrastructure.Services;
using Mod.Product.Interfaces;
using Mod.Product.Models;

namespace Mod.Product.Services;

public class ProductRepository: CachedRepositoryService<ProductEntity, ProductModel>, IProductRepository
{
    public ProductRepository(ApiDbContext apiDbContext, IMapper mapper, AppConfiguration configurationOptions): base(apiDbContext, mapper, configurationOptions )
    {
    }
}
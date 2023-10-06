using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Data.Db;
using Infrastructure.Services;
using Mod.Product.Interfaces;
using Mod.Product.Models;

namespace Mod.Product.Services;

public class ProductSqlRepository: CachedSqlRepositoryService<ProductEntity, ProductModel>, IProductRepository
{
    public ProductSqlRepository(ApiDbContext apiDbContext, IMapper mapper, AppConfiguration configurationOptions): base(apiDbContext, mapper, configurationOptions )
    {
    }
}
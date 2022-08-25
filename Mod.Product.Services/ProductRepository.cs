using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Db;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Mod.Product.Interfaces;
using ModProduct.Models;
using Services;

namespace Mod.Product.Services;

public class ProductRepository: CachedRepositoryService<ProductEntity, ProductModel>, IProductRepository
{
    public ProductRepository(ApiDbContext apiDbContext, IMapper mapper, IDistributedCache cache,
        IOptions<AppConfiguration> configurationOptions): base(apiDbContext, mapper, cache, configurationOptions )
    {
    }
}
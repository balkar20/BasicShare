using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Data.Db;
using Infrastructure.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Mod.Product.Interfaces;
using ModProduct.Models;

namespace Mod.Product.Services;

public class ProductRepository: CachedRepositoryService<ProductEntity, ProductModel>, IProductRepository
{
    public ProductRepository(ApiDbContext apiDbContext, IMapper mapper, IOptions<AppConfiguration> configurationOptions): base(apiDbContext, mapper, configurationOptions )
    {
    }
}
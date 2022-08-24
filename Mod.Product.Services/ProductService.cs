using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Mod.Product.Interfaces;
using ModProduct.Models;
using Serilog;

namespace Mod.Product.Base.Repositories;

public class ProductService: IProductService
{
    private readonly IProductRepository _repository;
    private readonly ILogger _logger;
    private readonly ProductApiConfiguration _configuration;

    public ProductService(
        ILogger logger,
        IOptions<ProductApiConfiguration> options,
        IProductRepository repository)
    {
        _repository = repository;
        _logger = logger;
        _configuration = options.Value;
    }

    public async Task<List<ProductModel>> GetAllProducts()
    {
        var products =  await _repository.GetAllMappedToModelAsync<ProductEntity>(o => o.OrderBy(j => j.Description), null, null, null);
        return products.ToList();
    }
}
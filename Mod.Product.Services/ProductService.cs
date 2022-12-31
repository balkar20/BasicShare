using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Serilog;
using Microsoft.Extensions.Options;
using Mod.Product.Interfaces;
using ModProduct.Models;

namespace Mod.Product.Base.Repositories;

public class ProductService: IProductService
{
    private readonly IProductRepository _repository;
    private readonly ILogger _logger;
    private readonly ProductApiConfiguration _configuration;

    public ProductService(
        ILogger logger,
        ProductApiConfiguration configuration,
        IProductRepository repository)
    {
        _repository = repository;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<List<ProductModel>> GetAllProducts()
    {
        var products =  await _repository.GetAllMappedToModelAsync<ProductEntity>(o => o.OrderBy(j => j.Description), null, null, null);
        return products.ToList();
    }
}
using Core.Base.DataBase.Entities;
using Mod.Product.Interfaces;
using ModProduct.Models;
using Serilog;

namespace Mod.Product.Base.Repositories;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly ILogger _logger;

    public ProductService(IProductRepository repository, ILogger logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<List<ProductModel>> GetAllProducts()
    {
        var products =  await _repository.GetAllMappedToModelAsync<ProductEntity>(o => o.OrderBy(j => j.Description), null, null, null);
        return products.ToList();
    }
}
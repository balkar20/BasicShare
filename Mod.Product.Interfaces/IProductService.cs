using Mod.Product.Models;

namespace Mod.Product.Interfaces;

public interface IProductService
{
    Task<List<ProductModel>> GetAllProducts();
    Task<ProductModel> UpdateProduct(ProductModel product);
    Task<ProductModel> CreateAsync(ProductModel requestProduct);
}
using ModProduct.Models;

namespace Mod.Product.Interfaces;

public interface IProductService
{
    Task<List<ProductModel>> GetAllProducts();
}
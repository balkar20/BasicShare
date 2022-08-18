using Db;
using Db.Entities;


namespace ModProduct.Repositories;

public class ProductRepository: GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApiDbContext apiDbContext): base(apiDbContext)
    {
        
    }
}
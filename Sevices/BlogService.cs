using Db;

namespace Sevices;

public class BlogService: IBlogService
{
    private readonly ApiDbContext _apiDbContext;

    public BlogService(ApiDbContext apiDbContext)
    {
        _apiDbContext = apiDbContext;
    }


    public IEnumerable<Product> GetBlogs()
    {
        return _apiDbContext.Products.ToList();
    }
}
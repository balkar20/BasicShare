using Db;

namespace Sevices;

public interface IBlogService
{
    IEnumerable<Product> GetBlogs();
}
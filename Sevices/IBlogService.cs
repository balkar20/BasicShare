using Db;
using Db.Entities;

namespace Sevices;

public interface IBlogService
{
    IEnumerable<Product> GetBlogs();
}
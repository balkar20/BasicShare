using Microsoft.EntityFrameworkCore;

namespace DataBaseCommon;

public class BaseDbContext: DbContext
{
    public BaseDbContext(DbContextOptions<BaseDbContext> options)
        : base(options)
    {
    }
}
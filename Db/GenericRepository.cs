using Db.Interfaces;

namespace Db;

public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class,IEntity,new()
{
    protected readonly ApiDbContext ApiDbContext;
 
    public GenericRepository(ApiDbContext customDbContext) => ApiDbContext = customDbContext;
 
    public IEnumerable<TEntity> GetAll() => ApiDbContext.Set<TEntity>();
 
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
 
        await ApiDbContext.AddAsync(entity);
        await ApiDbContext.SaveChangesAsync();
 
        return entity;
    }
 
}
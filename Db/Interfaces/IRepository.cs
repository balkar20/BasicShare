namespace Db.Interfaces;

public interface IRepository<TEntity> where TEntity : class, new()
{
    IEnumerable<TEntity> GetAll();
    Task<TEntity> AddAsync(TEntity entity);
}
namespace Infrastructure.Interfaces;

public interface IRepository<TEntity, TModel> where TEntity : class, new()
    where TModel : class, new()
{
    IEnumerable<TModel> GetAll();
    Task<TModel> AddAsync(TModel entity);
}
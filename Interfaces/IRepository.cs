using Core.Base.DataBase.Interfaces;

namespace Infrastructure.Interfaces;

public interface IRepository<TEntity, TModel> where TEntity : class, new()
    where TModel : class, new()
{
    Task<TModel> AddAsync(TModel entity);

    Task<IEnumerable<TModel>> GetAllMappedToModelAsync<TEntity>(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null,
        int? skip = null,
        int? take = null)
        where TEntity : class, IEntity;

    Task<TModel> UpdateAsync(TModel model);
}
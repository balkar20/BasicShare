using Core.Base.DataBase.Interfaces;

namespace Infrastructure.Interfaces;

public interface IReadRepository<TEntity, TModel>
{
    Task<IEnumerable<TModel>> GetAllMappedToModelAsync<TEntity>(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null,
        int? skip = null,
        int? take = null)
        where TEntity : class, IEntity;
}
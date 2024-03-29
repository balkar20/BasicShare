using System.Linq.Expressions;
using AutoMapper;
using Core.Base.DataBase.Interfaces;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GenericSqlRepository<TEntity, TModel> : IRepository<TEntity, TModel> where TEntity : class, IEntity
    where TModel : class
{
    protected readonly DbContext _context;
    protected readonly IMapper _mapper;
    private DbSet<TEntity> _table;
    private List<TEntity> guids = new List<TEntity>();

    public GenericSqlRepository(DbContext customDbContext, IMapper mapper)
    {
        _context = customDbContext;
        _mapper = mapper;
        _table = _context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TModel>> GetAllMappedToModelAsync<TEntity>(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy,
        string? includeProperties,
        int? skip = null,
        int? take = null)
        where TEntity : class, IEntity
    {
        var qury =  await GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take)
            .ToListAsync();
        return qury.Select(_mapper.Map<TModel>);
    }

    public virtual async Task<TModel> GetByIdASync(long id)
    {
        var model = await _table.FindAsync(id);
        return _mapper.Map<TModel>(model);
    }

    public virtual async Task<TModel> AddAsync(TModel model)
    {
        ArgumentNullException.ThrowIfNull(model);
        var entity = _mapper.Map<TEntity>(model);
        entity.Id = entity.Id == (Guid.Empty) ? Guid.NewGuid(): entity.Id;
        if (guids.Any(g => g.Id == entity.Id))
        {
            throw new Exception("lkljlkjlkj");
        }
        guids.Add(entity);
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
 
        return model;
    }
    
    
    public virtual async Task<TModel> UpdateAsync(TModel model)
    {
        TEntity entity = _mapper.Map<TEntity>(model);
        _context.Set<TEntity>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return await Task.FromResult(model);
    }
    
    #region Private methods
    
    protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null,
        int? skip = null,
        int? take = null)
        where TEntity : class, IEntity
    {
        includeProperties = includeProperties ?? string.Empty;
        IQueryable<TEntity> query = _context.Set<TEntity>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
                     (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        if (take.HasValue)
        {
            query = query.Take(take.Value);
        }

        return query;
    }

    #endregion
}
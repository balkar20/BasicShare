using AutoMapper;
using Core.Base.DataBase.Interfaces;
using Db;
using Infrastructure.Interfaces;

public class GenericRepository<TEntity, TModel> : IRepository<TEntity, TModel> where TEntity : class, IEntity,new()
    where TModel : class,new()
{
    protected readonly ApiDbContext ApiDbContext;
    protected readonly IMapper _mapper;

    public GenericRepository(ApiDbContext customDbContext, IMapper mapper)
    {
        ApiDbContext = customDbContext;
        _mapper = mapper;
    }

    public IEnumerable<TModel> GetAll() => ApiDbContext.Set<TEntity>().Select(_mapper.Map<TModel>);
 
    public async Task<TModel> AddAsync(TModel model)
    {
        ArgumentNullException.ThrowIfNull(model);
 
        await ApiDbContext.AddAsync(_mapper.Map<TEntity>(model));
        await ApiDbContext.SaveChangesAsync();
 
        return model;
    }
 
}
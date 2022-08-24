using System.Text;
using System.Text.Json;
using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Interfaces;
using Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Serilog;

namespace Services;

public abstract class CachedRepositoryService<TEntity, TModel>: GenericRepository<TEntity, TModel> where TEntity : class, IEntity,new()
    where TModel : class,new()
{
    private readonly IDistributedCache _cache;
    private readonly AppConfiguration _configuration;
    private const string EntityName = nameof(TEntity);
    
    private const string AllDataCacheKey = $"{EntityName}-AllData";

    protected CachedRepositoryService(
        ApiDbContext customDbContext,
        IMapper mapper,
        IDistributedCache cache,
        IOptions<AppConfiguration> configurationOptions): base(customDbContext, mapper)
    {
        _cache = cache;
        _configuration = configurationOptions.Value;
    }

    public override async  Task<IEnumerable<TModel>> GetAllMappedToModelAsync<TEntity>(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
        string includeProperties,
        int? skip = null,
        int? take = null)
    {
        if (!_configuration.UseCache)
        {
            return await base.GetAllMappedToModelAsync<TEntity>(orderBy, includeProperties, skip, take);
        }
        
        byte[] cachedData = await _cache.GetAsync(AllDataCacheKey);
        IEnumerable<TModel> modelData;
        string cachedDataString;
        if (cachedData != null)
        {
            // If the data is found in the cache, encode and deserialize cached data.
            cachedDataString = Encoding.UTF8.GetString(cachedData);
            modelData = JsonSerializer.Deserialize<IEnumerable<TModel>>(cachedDataString);
        }
        else
        {
            // If the data is not found in the cache, then fetch data from database
            modelData = await base.GetAllMappedToModelAsync<TEntity>(orderBy, includeProperties, skip, take);

            // Serializing the data
            cachedDataString = JsonSerializer.Serialize(modelData);
            var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);

            // Setting up the cache options
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                .SetSlidingExpiration(TimeSpan.FromMinutes(3));

            // Add the data into the cache
            await _cache.SetAsync(AllDataCacheKey, dataToCache, options);
        }
        
        return modelData;
    }
    
    public override async Task<TModel> UpdateAsync(TModel model)
    {
        TEntity entity = _mapper.Map<TEntity>(model);
        _context.Set<TEntity>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        
        await _context.SaveChangesAsync();
        await _cache.RemoveAsync(AllDataCacheKey);
        await _cache.RemoveAsync($"{EntityName}-{((IEntity)entity).Id.ToString()}");
        
        return await Task.FromResult(model);
    }

    public override async Task<TModel> GetByIdASync(long id)
    {
        if (!_configuration.UseCache)
        {
            return await base.GetByIdASync(id);
        }

        byte[] cachedData = await _cache.GetAsync($"{EntityName}-{id}");
        TModel modelData;
        string cachedDataString;
        if (cachedData != null)
        {
            // If the data is found in the cache, encode and deserialize cached data.
            cachedDataString = Encoding.UTF8.GetString(cachedData);
            modelData = JsonSerializer.Deserialize<TModel>(cachedDataString);
        }
        else
        {
            // If the data is not found in the cache, then fetch data from database
            modelData = await base.GetByIdASync(id);

            // Serializing the data
            cachedDataString = JsonSerializer.Serialize(modelData);
            var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);

            // Setting up the cache options
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                .SetSlidingExpiration(TimeSpan.FromMinutes(3));

            // Add the data into the cache
            await _cache.SetAsync(AllDataCacheKey, dataToCache, options);
        }

        return modelData;
    }
}
using System.Text;
using System.Text.Json;
using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Interfaces;
using Core.Base.Exceptions;
using Microsoft.EntityFrameworkCore;
using RedisCache;
using StackExchange.Redis;

namespace Infrastructure.Services;

public abstract class CachedSqlRepositoryService<TEntity, TModel>: GenericSqlRepository<TEntity, TModel> where TEntity : class, IEntity
    where TModel : class
{
    private readonly IDatabaseAsync _redisDbAsync;
    private readonly AppConfiguration _configuration;
    private const string EntityName = nameof(TEntity);
    
    private const string AllDataCacheKey = $"{EntityName}-AllData";

    protected CachedSqlRepositoryService(
        DbContext customDbContext,
        IMapper mapper,
        AppConfiguration configurationOptions): base(customDbContext, mapper)
    {
        _configuration = configurationOptions;
        if (_configuration.DockerRunning && _configuration.RedisUrl != "redis:6379" || 
            !_configuration.DockerRunning && _configuration.RedisUrl != "localhost:6379")
        {
            throw new AppException("Not redis url");
        }
        _redisDbAsync = new RedisContext(_configuration.RedisUrl).Connection.GetDatabase();
    }

    public override async  Task<IEnumerable<TModel>> GetAllMappedToModelAsync<TEntity>(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy,
        string? includeProperties,
        int? skip = null,
        int? take = null)
    {
        if (!_configuration.UseCache)
        {
            return await base.GetAllMappedToModelAsync<TEntity>(orderBy, includeProperties, skip, take);
        }
        
        var cachedData = await _redisDbAsync.StringGetAsync(AllDataCacheKey);
        // var cachedData = await _cache.StringGetAsync(AllDataCacheKey);
        IEnumerable<TModel> modelData;
        string cachedDataString;
        if (cachedData.HasValue)
        {
            // If the data is found in the cache, encode and deserialize cached data.
            // cachedDataString = Encoding.UTF8.GetString(cachedData);
            modelData = JsonSerializer.Deserialize<IEnumerable<TModel>>(cachedData) ?? throw new InvalidOperationException();
        }
        else
        {
            modelData = await base.GetAllMappedToModelAsync<TEntity>(orderBy, includeProperties, skip, take);

            cachedDataString = JsonSerializer.Serialize(modelData);

            _redisDbAsync.StringSetAsync(AllDataCacheKey, cachedDataString);
        }
        
        return modelData;
    }
    
    public override async Task<TModel> UpdateAsync(TModel model)
    {
        TEntity entity = _mapper.Map<TEntity>(model);
        _context.Set<TEntity>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        
        await _context.SaveChangesAsync();
        await _redisDbAsync.KeyDeleteAsync($"{EntityName}-{((IEntity)entity).Id.ToString()}");
        // await _redisCache.RemoveAsync($"{EntityName}-{((IEntity)entity).Id.ToString()}");
        
        return await Task.FromResult(model);
    }

    public override async Task<TModel> GetByIdASync(long id)
    {
        if (!_configuration.UseCache)
        {
            return await base.GetByIdASync(id);
        }

        var cachedData = await _redisDbAsync.StringGetAsync($"{EntityName}-{id.ToString()}");
        // byte[] cachedData = await _redisCache.GetAsync($"{EntityName}-{id}");
        TModel modelData;
        string cachedDataString;
        if (cachedData.HasValue)
        {
            // If the data is found in the cache, encode and deserialize cached data.
            cachedDataString = Encoding.UTF8.GetString(cachedData);
            modelData = JsonSerializer.Deserialize<TModel>(cachedDataString) ?? throw new InvalidOperationException();
        }
        else
        {
            // If the data is not found in the cache, then fetch data from database
            modelData = await base.GetByIdASync(id);

            // Serializing the data
            cachedDataString = JsonSerializer.Serialize(modelData);
            var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);

            // Setting up the cache options
            // DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
            //     .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
            //     .SetSlidingExpiration(TimeSpan.FromMinutes(3));

            // Add the data into the cache
            // await _redisCache.SetAsync(AllDataCacheKey, dataToCache, options);
            await _redisDbAsync.StringSetAsync(AllDataCacheKey, cachedDataString);
        }

        return modelData;
    }
}
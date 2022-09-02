using AutoMapper;
using Core.Auh.Entities;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Data.Db;
using Infrastructure.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;


namespace Mod.Auth.Services;

public class AuthRepository: CachedRepositoryService<UserEntity, UserModel>, IAuthRepository
{
    public AuthRepository(ApiDbContext apiDbContext, IMapper mapper, IDistributedCache cache,
        IOptions<AppConfiguration> configurationOptions): base(apiDbContext, mapper, cache, configurationOptions )
    {
    }
}
using AutoMapper;
using Core.Auh.Entities;
using Core.Base.Configuration;
using Data.IdentityDb;
using Infrastructure.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;


namespace Mod.Auth.Services;

//public class AuthRepository: CachedRepositoryService<UserEntity, LoginModel>, IAuthRepository
//{
//    public AuthRepository(ApplicationContext apiDbContext, IMapper mapper, IDistributedCache cache,
//        AppConfiguration configurationOptions): base(apiDbContext, mapper, cache, configurationOptions )
//    {
//    }
//}
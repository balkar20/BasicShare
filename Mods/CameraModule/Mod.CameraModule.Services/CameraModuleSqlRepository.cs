using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Infrastructure.Services;
using Storage.AppStorage;
using Mod.CameraModule.Interfaces;
using Mod.CameraModule.Models;

namespace Mod.CameraModule.Services;

public class CameraModuleSqlRepository: CachedSqlRepositoryService<CameraModuleEntity, CameraModuleModel>, ICameraModuleRepository
{
    public CameraModuleSqlRepository(ApiDbContext apiDbContext, IMapper mapper, AppConfiguration configurationOptions): base(apiDbContext, mapper, configurationOptions )
    {
    }
}
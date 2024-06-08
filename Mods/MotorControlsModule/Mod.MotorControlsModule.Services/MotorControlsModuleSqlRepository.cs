using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Infrastructure.Services;
using Storage.AppStorage;
using Mod.MotorControlsModule.Interfaces;
using Mod.MotorControlsModule.Models;

namespace Mod.MotorControlsModule.Services;

public class MotorControlsModuleSqlRepository: CachedSqlRepositoryService<MotorControlsModuleEntity, MotorControlsModuleModel>, IMotorControlsModuleRepository
{
    public MotorControlsModuleSqlRepository(ApiDbContext apiDbContext, IMapper mapper, AppConfiguration configurationOptions): base(apiDbContext, mapper, configurationOptions )
    {
    }
}
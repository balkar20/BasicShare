


using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Storage.AppStorage;
using Infrastructure.Services;
using Mod.Shipment.Interfaces;
using Mod.Shipment.Models;

namespace Mod.Shipment.Base.Repositories;

public class ShipmentSqlRepository: CachedSqlRepositoryService<ShipmentEntity, ShipmentModel>, IShipmentRepository
{
    public ShipmentSqlRepository(ApiDbContext apiDbContext, IMapper mapper, AppConfiguration configurationOptions): base(apiDbContext, mapper, configurationOptions )
    {
    }
}


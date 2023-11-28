using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Infrastructure.Services;
using Storage.AppStorage;
using Mod.Shipment.Interfaces;
using Mod.Shipment.Models;

namespace Mod.Shipment.Services;

public class ShipmentSqlRepository: CachedSqlRepositoryService<ShipmentEntity, ShipmentModel>, IShipmentRepository
{
    public ShipmentSqlRepository(ApiDbContext apiDbContext, IMapper mapper, AppConfiguration configurationOptions): base(apiDbContext, mapper, configurationOptions )
    {
    }
}
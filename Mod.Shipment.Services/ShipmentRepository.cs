


using AutoMapper;
using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Data.Db;
using Infrastructure.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Mod.Shipment.Interfaces;
using Mod.Shipment.Models;

namespace Mod.Shipment.Base.Repositories;

public class ShipmentRepository: CachedRepositoryService<ShipmentEntity, ShipmentModel>, IShipmentRepository
{
    public ShipmentRepository(ApiDbContext apiDbContext, IMapper mapper, IDistributedCache cache,
    IOptions<AppConfiguration> configurationOptions): base(apiDbContext, mapper, cache, configurationOptions )
    {
    }
}


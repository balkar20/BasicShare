using Core.Base.DataBase.Entities;
using Infrastructure.Interfaces;
using Mod.PowerSupply.Models;

namespace Mod.PowerSupply.Interfaces;

public interface IPowerSupplyRepository: IRepository<PowerSupplyEntity, PowerSupplyModel>
{
    
}
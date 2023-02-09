using Core.Base.DataBase.Entities;
using Infrastructure.Interfaces;
using Mod.Pooper.Models;

namespace Mod.Pooper.Interfaces;

public interface IPooperRepository: IRepository<PooperEntity, PooperModel>
{
    
}
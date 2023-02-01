using Mod.Pooper.Models;
using Core.Base;

namespace Mod.Pooper.Interfaces;

public interface IPooperService
{
    Task<List<PooperModel>> GetAllPoopers();
}
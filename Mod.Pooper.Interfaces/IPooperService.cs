using Mod.Pooper.Models;

namespace Mod.Pooper.Interfaces;

public interface IPooperService
{
    Task<List<PooperModel>> GetAllPoopers();
}
using Mod.Auth.Models;

namespace Mod.Auth.Interfaces;

public interface IAuthService
{
    Task<List<UserModel>> GetAllAuths();
}
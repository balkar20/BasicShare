using Mod.Auth.Models;

namespace Mod.Auth.Interfaces;

public interface IAuthService
{
    //Task<List<AuthModel>> GetAllAuths();
    Task<AuthResponseModel> LogIn(AuthModel userForAuthentication);
}
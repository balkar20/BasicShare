using Mod.Auth.Models;

namespace Mod.Auth.Interfaces;

public interface IAuthService
{
    //Task<List<AuthModel>> GetAllAuths();
    Task<AuthResponseModel> LogIn(AuthModel userForAuthentication);

    Task<RegisterResponseModel> RegisterUser(AuthModel userForAuthentication);
    Task<RegisterResponseModel> RegisterAdmin(AuthModel userForAuthentication);

    //Task LogOut();
}
using Mod.Auth.Models;

namespace Mod.Auth.Interfaces;

public interface IAuthService
{
    //Task<List<AuthModel>> GetAllAuths();
    Task<LoginResponseModel> LogIn(LoginModel userForAuthentication);

    Task<RegisterResponseModel> RegisterUser(LoginModel userForAuthentication);
    Task<RegisterResponseModel> RegisterAdmin(LoginModel userForAuthentication);

    //Task LogOut();
}
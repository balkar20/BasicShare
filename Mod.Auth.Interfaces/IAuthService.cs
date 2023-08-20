using Core.Transfer;
using Mod.Auth.Models;

namespace Mod.Auth.Interfaces;

public interface IAuthService
{
    Task<List<UserModel>> GetAllPoopers(DataListPagingModel dataListPagingModel);

    Task<UserDataListResult> GetPaginatedUsers(DataListPagingModel dataListPagingModel);
    
    Task<LoginResponseModel> LogIn(LoginModel userForAuthentication);

    Task<RegisterResponseModel> RegisterUser(RegisterModel userForAuthentication);

    Task<BaseResponseResult> SavePooper(UserModel userModel);
    
    //Task LogOut();
}
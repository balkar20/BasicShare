using Core.Transfer;
using IdentityProvider.Shared;

namespace ClientLibrary.Interfaces.Particular;

public interface IAuthenticationService
{
    public bool IsAuthenticated { get; set; }
    
    IBaseCrudService<LoginViewModel, BaseResponseResult, LoginResponseViewModel> CrudService { get; }
    
    Task<ResponseResultWithData<LoginResponseViewModel>> LigInAsync();
    Task Logout();
}
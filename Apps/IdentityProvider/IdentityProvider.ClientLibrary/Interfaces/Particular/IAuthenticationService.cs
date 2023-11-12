using Core.Transfer;
using IdentityProvider.Shared;

namespace ClientLibrary.Interfaces.Particular;

public interface IAuthenticationService
{
    public bool IsAuthenticated { get; set; }
    
    public string UserName { get; set; }
    
    public string UserRole { get; set; }
    
    IBaseCrudService<LoginViewModel, BaseResponseResult, LoginResponseViewModel> LoginCrudService { get; }
    
    IBaseCrudService<RegisterViewModel, BaseResponseResult, LoginResponseViewModel> RegisterCrudService { get; }
    
    Task<ResponseResultWithData<LoginResponseViewModel>> LigInAsync();
    
    Task<ResponseResultWithData<LoginResponseViewModel>> RegisterAsync();
    
    Task Logout();
    
    Task GetClaimsPrincipalData();
}
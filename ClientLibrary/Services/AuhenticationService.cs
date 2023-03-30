using Blazored.LocalStorage;
using ClientLibrary.Interfaces;
using ClientLibrary.Interfaces.Particular;
using Core.Transfer;
using IdentityProvider.Shared;

namespace ClientLibrary.Services;

public class AuthenticationService : IAuthenticationService
{
    private const string TokenKey = "authToken";
    private readonly ILocalStorageService _localStorage;
    private readonly AuthStateProvider _authenticationStateProvider;
    
    public AuthenticationService(
        IBaseCrudService<LoginViewModel, BaseResponseResult, LoginResponseViewModel> loginCrudService,
        IBaseCrudService<RegisterViewModel, BaseResponseResult, LoginResponseViewModel> registerCrudService,
        ILocalStorageService localStorage, 
        AuthStateProvider authenticationStateProvider)
    {
        LoginCrudService = loginCrudService;
        RegisterCrudService = registerCrudService;
        _localStorage = localStorage;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public bool IsAuthenticated { get; set; }
    public IBaseCrudService<LoginViewModel, BaseResponseResult, LoginResponseViewModel> LoginCrudService { get; }
    public IBaseCrudService<RegisterViewModel, BaseResponseResult, LoginResponseViewModel> RegisterCrudService { get; }

    public async Task<ResponseResultWithData<LoginResponseViewModel>> LigInAsync()
    {
        var loginResult = await LoginCrudService.CreateDataAsync();
        if (loginResult.IsSuccess)
        {
            await _localStorage.SetItemAsync(TokenKey, loginResult?.Data?.Token);
            IsAuthenticated = true;
            await _authenticationStateProvider.NotifyUserAuthentication(LoginCrudService.MvvmViewModel.Data.Email);
        }

        return loginResult;
    }

    public async Task<ResponseResultWithData<LoginResponseViewModel>> RegisterAsync()
    {
        var loginResult = await RegisterCrudService.CreateDataAsync();
        if (loginResult.IsSuccess)
        {
            await _localStorage.SetItemAsync(TokenKey, loginResult?.Data?.Token);
            IsAuthenticated = true;
            await _authenticationStateProvider.NotifyUserAuthentication(LoginCrudService.MvvmViewModel.Data.Email);
        }

        return loginResult;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync(TokenKey);
        IsAuthenticated = false;
        _authenticationStateProvider.NotifyUserLogout();
    }
}
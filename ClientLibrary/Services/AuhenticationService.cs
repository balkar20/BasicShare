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
        IBaseCrudService<LoginViewModel, BaseResponseResult, LoginResponseViewModel> crudService,
        ILocalStorageService localStorage, 
        AuthStateProvider authenticationStateProvider)
    {
        CrudService = crudService;
        _localStorage = localStorage;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public bool IsAuthenticated { get; set; }
    public IBaseCrudService<LoginViewModel, BaseResponseResult, LoginResponseViewModel> CrudService { get; }

    public async Task<ResponseResultWithData<LoginResponseViewModel>> LigInAsync()
    {
        var loginResult = await CrudService.CreateDataAsync();
        if (loginResult.IsSuccess)
        {
            await _localStorage.SetItemAsync(TokenKey, loginResult?.Data?.Token);
            IsAuthenticated = true;
            await _authenticationStateProvider.NotifyUserAuthentication(CrudService.MvvmViewModel.Data.Email);
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
using System.Net;
using Blazored.LocalStorage;
using ClientLibrary.Interfaces;
using ClientLibrary.Interfaces.Particular;
using Core.Transfer;
using IdentityProvider.Shared;
using TinyCsvParser.Tokenizer.RFC4180;

namespace ClientLibrary.Services;

public class AuthenticationService : IAuthenticationService
{
    private const string TokenKey = "authToken";
    private readonly ILocalStorageService _localStorage;
    public AuthenticationService(IBaseCrudService<LoginViewModel, BaseResponseResult, LoginResponseViewModel> crudService , ILocalStorageService localStorage)
    {
        CrudService = crudService;
        _localStorage = localStorage;
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
        }

        return loginResult;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync(TokenKey);
        IsAuthenticated = false;
        // CrudService.
    }
}
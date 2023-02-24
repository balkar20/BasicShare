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
    private readonly ILocalStorageService _localStorage;
    public AuthenticationService(IBaseCrudService<LoginViewModel, BaseResponseResult, LoginResponseViewModel> crudService , ILocalStorageService localStorage)
    {
        CrudService = crudService;
        _localStorage = localStorage;
    }

    public IBaseCrudService<LoginViewModel, BaseResponseResult, LoginResponseViewModel> CrudService { get; }

    public async Task<ResponseResultWithData<LoginResponseViewModel>> LigInAsync(LoginViewModel model)
    {
        var loginResult = await CrudService.CreateDataAsync(model);
        if (loginResult.IsSuccess)
        {
            await _localStorage.SetItemAsync("authToken", loginResult?.Data?.Token);
        }

        return loginResult;
    }
    
    public interface IAuthenticationService
    {
        
    }

}
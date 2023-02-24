using System.Net;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using ClientLibrary.Interfaces;
using Core.Transfer;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components;
using Mod.Auth.Models;
using TinyCsvParser.Tokenizer.RFC4180;

namespace ClientLibrary.Components;

public partial class Login
{

    private readonly IBaseCrudService<LoginViewModel, BaseResponseResult, LoginResponseViewModel> _loginCrudService;
    private readonly IBaseMvvmViewModel<LoginViewModel> _mvvmViewModel;

    public Login(IBaseCrudService<LoginViewModel, BaseResponseResult, LoginResponseViewModel> loginCrudService)
    {
        _loginCrudService = loginCrudService;
        _mvvmViewModel = loginCrudService.MvvmViewModel;
    }

    private async void OnValidSubmit()
    {
        //private readonly ILoc
        // reset alerts on submit
        //AlertService.Clear();
        await _loginCrudService.CreateDataAsync(_mvvmViewModel.Data);
    }
    
}
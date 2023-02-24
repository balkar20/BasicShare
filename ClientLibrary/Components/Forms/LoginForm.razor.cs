using System.Net;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using ClientLibrary.Interfaces;
using ClientLibrary.Interfaces.Particular;
using Core.Transfer;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components;
using Mod.Auth.Models;
using TinyCsvParser.Tokenizer.RFC4180;

namespace ClientLibrary.Components.Forms;

public partial class LoginForm
{

    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }
    
    private IBaseMvvmViewModel<LoginViewModel> _mvvmViewModel;

    private async void OnValidSubmit()
    {
        //private readonly ILoc
        // reset alerts on submit
        //AlertService.Clear();
        await AuthenticationService.LigInAsync(_mvvmViewModel.Data);
    }

    protected override Task OnInitializedAsync()
    {
        _mvvmViewModel = AuthenticationService.CrudService.MvvmViewModel;
        _mvvmViewModel.Data = new LoginViewModel();
        return base.OnInitializedAsync();
    }
}
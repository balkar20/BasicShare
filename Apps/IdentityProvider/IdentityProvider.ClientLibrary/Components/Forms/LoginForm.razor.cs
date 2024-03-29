using System.Net;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using ClientLibrary.Interfaces;
using ClientLibrary.Interfaces.Particular;
using Core.Transfer;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components;
using TinyCsvParser.Tokenizer.RFC4180;

namespace ClientLibrary.Components.Forms;

public partial class LoginForm : ComponentBase
{
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }
    
    private IBaseMvvmViewModel<LoginViewModel> _mvvmViewModel;

    private async Task OnValidSubmit()
    {
        //private readonly ILoc
        // reset alerts on submit
        //AlertService.Clear();
        var data= await AuthenticationService.LigInAsync();
    }

    //protected override Task OnInitializedAsync()
    //{
    //    _mvvmViewModel = AuthenticationService.LoginCrudService.MvvmViewModel;
    //    _mvvmViewModel.Data = new LoginViewModel();
    //    return base.OnInitializedAsync();
    //}

    protected override Task OnInitializedAsync()
    {
        _mvvmViewModel = AuthenticationService.LoginCrudService.MvvmViewModel;
        _mvvmViewModel.Data = new LoginViewModel();
        return base.OnInitializedAsync();
    }
}
using ClientLibrary.Components.Dialogs;
using ClientLibrary.Interfaces.Particular;
using IdentityProvider.Client.Pages;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace IdentityProvider.Client.Shared;

public partial class MainLayout
{
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }
    [Inject]
    IDialogService DialogService { get; set; }

    void Login()
    {
        DialogService.Show<LoginFormDialog>();
    }
    
    private void Logout()
    {
        AuthenticationService.Logout();
    }
    
    private void Register()
    {
        // DialogService.Show<RegisterFormDialog>();
    }

}
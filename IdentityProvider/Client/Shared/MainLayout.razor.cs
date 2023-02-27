using ClientLibrary.Components.Dialogs;
using ClientLibrary.Interfaces.Particular;
using IdentityProvider.Client.Pages;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace IdentityProvider.Client.Shared;

public partial class MainLayout
{
    Justify _justify = Justify.FlexEnd;
    
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
        StateHasChanged();
    }
    
    private void Register()
    {
        // DialogService.Show<RegisterFormDialog>();
    }

}
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

    async Task Login()
    {
        // await DialogService.ShowAsync<LoginFormDialog>(null, new Dictionary<string, object>() { { "OnClosed", EventCallback.Factory.Create(this, HandleDialogClosed) }});
        
        var parameters = new DialogParameters();
        parameters.Add("OnClosed", EventCallback.Factory.Create(this, HandleDialogClosed));

        await DialogService.ShowAsync<LoginFormDialog>("Login", parameters);


    }
    
    private async Task HandleDialogClosed()
    {
        Console.WriteLine("HandleDialogClosed");
    }
    
    async Task Logout()
    {
        await AuthenticationService.Logout();
    }
    
    private void Register()
    {
        // DialogService.Show<RegisterFormDialog>();
    }

}
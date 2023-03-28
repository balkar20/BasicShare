using ClientLibrary.Components.Dialogs;
using ClientLibrary.Interfaces.Particular;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace IdentityProvider.Client.Shared;

public partial class MainLayout
{
    Justify _justify = Justify.FlexStart;
    
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }
    
    [Inject]
    public ISnackbar SnackBarService { get; set; }
    
    [Inject]
    IDialogService DialogService { get; set; }
    
    public RenderFragment MyMarkup { get; set; }

    async Task Login()
    {
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
    
    async Task Register()
    {
        var parameters = new DialogParameters();
        parameters.Add("OnClosed", EventCallback.Factory.Create(this, HandleDialogClosed));
        DialogOptions fullScreen = new DialogOptions() { FullScreen = true, CloseButton = true };

        await DialogService.ShowAsync<RegisterFormDialog>("Register", parameters, fullScreen);
    }
    
    // private void ShowAccountOptions()
    // {
    //     MyMarkup = builder =>
    //     {
    //         builder.OpenComponent(0, typeof(PooperForm));
    //         builder.AddComponentReferenceCapture(1, (value) => PooperFormOnstance = (PooperForm)value);
    //         builder.CloseComponent();
    //     };
    //     
    //     SnackBarService.Add
    //         (
    //             @MyMarkup
    //             );
    // }
}
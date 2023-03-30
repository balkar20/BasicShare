using System.Security.Claims;
using ClientLibrary.Interfaces;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ClientLibrary.Components.Dialogs;
using Core.Transfer;
using IdentityProvider.Client.Shared;
using Microsoft.AspNetCore.Components.Authorization;

namespace IdentityProvider.Client.Pages;

public partial class PoopPeople : ComponentBase
{
    [CascadingParameter] public MainLayout Layout { get; set; }
    private string authMessage;
    private string surnameMessage;
    private IEnumerable<Claim> claims = Enumerable.Empty<Claim>();

    private string girlName;
    private string girlEmail;
    private int girlAge;
    private string girlCity;
    private bool isOpen = true;

    [Inject] IDialogService DialogService { get; set; }
    [Inject] public AuthStateProvider AuthStateProvider { get; set; }

    IBaseMvvmViewModel<PooperViewModel> PooperViewModel { get; set; }

    [Inject] IBaseCrudService<PooperViewModel, BaseResponseResult, PooperViewModel> CrudService { get; set; }

    private void OpenDialog(PooperViewModel pooperViewModel)
    {
        PooperViewModel.Data = pooperViewModel;

        DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Large };
        DialogService.Show<PooperFormDialog>("Edit Pooper", closeOnEscapeKey);
    }

    protected override async Task OnInitializedAsync()
    {
        PooperViewModel = CrudService.MvvmViewModel;
        await CrudService.GetModelListAsync();
        AuthStateProvider.AuthenticationStateChanged += AuthStateProviderOnAuthenticationStateChanged; 
        PooperViewModel.PropertyChanged += async (sender, e) => { await InvokeAsync(() => { StateHasChanged(); }); };
        await base.OnInitializedAsync();
    }

    private void AuthStateProviderOnAuthenticationStateChanged(Task<AuthenticationState> task)
    {
        var state = task.Result;
        var user = state.User;
        StateHasChanged();
    }
}
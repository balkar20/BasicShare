using System.Security.Claims;
using ClientLibrary.Interfaces;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ClientLibrary.Components.Dialogs;
using ClientLibrary.Resources;
using Core.Transfer;
using IdentityProvider.Client.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;
using SortDirection = Core.Transfer.SortDirection;

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

    public DataListPagingModel DataListPagingModel { get; set; }

    private async Task SetSelected(int value)
    {
        DataListPagingModel.CurrentPage = value;

        await CrudService.GetModelListAsync(DataListPagingModel);
    }

    private int _countOfPages;

    [Inject] IDialogService DialogService { get; set; }
    [Inject] public AuthStateProvider AuthStateProvider { get; set; }
    [Inject] public IStringLocalizer<Resource> Localizer { get; set; }

    IBaseMvvmViewModel<PooperViewModel> PooperViewModel { get; set; }

    [Inject] IBaseCrudService<PooperViewModel, BaseResponseResult, PooperViewModel> CrudService { get; set; }

    private void OpenDialog(PooperViewModel pooperViewModel)
    {
        PooperViewModel.Data = pooperViewModel;

        DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true, FullScreen = true};
        DialogService.Show<PooperFormDialog>("Edit Pooper", closeOnEscapeKey);
    }

    protected override async Task OnInitializedAsync()
    {
        DataListPagingModel = new DataListPagingModel()
        {
            CurrentPage = 1,
            PageSize = 6,
            SortBy = "Op",
            SortDirection = SortDirection.Asc
        };
        PooperViewModel = CrudService.MvvmViewModel;
        PooperViewModel.PageSize = DataListPagingModel.PageSize;
        await CrudService.GetModelListAsync(DataListPagingModel);
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
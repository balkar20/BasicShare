using System.Security.Claims;
using ClientLibrary.Interfaces;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ClientLibrary.Components.Dialogs;
using ClientLibrary.Resources;
using Core.Transfer;
using Core.Transfer.Filtering;
using IdentityProvider.Client.Shared.Resources;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using NPOI.OpenXmlFormats.Spreadsheet;
using SortDirection = Core.Transfer.SortDirection;

namespace IdentityProvider.Client.Pages;

public partial class BasicSharePeople : ComponentBase
{
    [CascadingParameter] public Shared.MainLayout Layout { get; set; }
    private bool _overrideStyles;
    private string authMessage;
    private string surnameMessage;
    
    bool mandatory = true;
    
    private MudChip[] selectedChips;

    public DataListPagingModel DataListPagingModel { get; set; }

    private async Task SetSelected(int value)
    {
        DataListPagingModel.CurrentPage = value;

        await CrudService.LoadModelListAsync(DataListPagingModel);
    }
    
    private bool _processing;

    [Inject] IDialogService DialogService { get; set; }
    [Inject] public AuthStateProvider AuthStateProvider { get; set; }
    [Inject] IStringLocalizer<Resource> Localizer { get; set; }

    IBaseMvvmViewModel<UserViewModel> PooperViewModel { get; set; }

    [Inject] IBaseCrudService<UserViewModel, BaseResponseResult, UserViewModel> CrudService { get; set; }

    private void OpenDialog(UserViewModel userViewModel)
    {
        PooperViewModel.Data = userViewModel;

        DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true, FullScreen = true};
        DialogService.Show<PooperFormDialog>(Localizer.GetString(ClientResourceConstants.Amend), closeOnEscapeKey);
    }

    protected override async Task OnInitializedAsync()
    {
        DataListPagingModel = new DataListPagingModel()
        {
            CurrentPage = 1,
            PageSize = 6,
            SortBy = "Op",
            SortDirection = SortDirection.Asc,
            Filter = new Filter()
            {
                Labels = new HashSet<string>(),
                StringValue = string.Empty,
                Location = string.Empty,
            }
        };
        PooperViewModel = CrudService.MvvmViewModel;
        PooperViewModel.PageSize = DataListPagingModel.PageSize;
        await CrudService.LoadModelListAsync(DataListPagingModel);
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

    private async Task FindUsersInCache()
    {

        await CrudService.LoadModelListAsync(DataListPagingModel);
    }
    
    private void FilterDataListOnKeyUp(KeyboardEventArgs obj)
    {
        CrudService.FilterDataListOnClient(DataListPagingModel);
    }

    private void ClickChipHandle(MouseEventArgs arg)
    {
        DataListPagingModel.Filter.Labels = new HashSet<string>(selectedChips.Select(c => c.Value.ToString()));

        CrudService.FilterDataListOnClient(DataListPagingModel);
    }
}
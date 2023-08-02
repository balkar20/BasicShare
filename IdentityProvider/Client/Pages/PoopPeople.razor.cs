using System.Security.Claims;
using ClientLibrary.Interfaces;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ClientLibrary.Components.Dialogs;
using Core.Transfer;
using IdentityProvider.Client.Shared.Resources;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using SortDirection = Core.Transfer.SortDirection;

namespace IdentityProvider.Client.Pages;

public partial class PoopPeople : ComponentBase
{
    [CascadingParameter] public Shared.MainLayout Layout { get; set; }
    private bool _overrideStyles;
    private string authMessage;
    private string surnameMessage;
    
    bool mandatory = true;
    
    private MudChip[] selectedChips;
    
    
    
    public string searchString{ get; set; }

    private List<string> claims = Enumerable.Empty<string>().ToList();

    private string girlName;
    private string girlEmail;
    private int girlAge;
    private string girlCity;
    private bool isOpen = true;

    public DataListPagingModel DataListPagingModel { get; set; }

    private async Task SetSelected(int value)
    {
        DataListPagingModel.CurrentPage = value;

        await CrudService.ShowModelListAsync(DataListPagingModel);
    }

    private int _countOfPages;
    private bool _processing;

    [Inject] IDialogService DialogService { get; set; }
    [Inject] public AuthStateProvider AuthStateProvider { get; set; }
    [Inject] IStringLocalizer<Resource> Localizer { get; set; }

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
        await CrudService.ShowModelListAsync(DataListPagingModel);
        claims =  CrudService.MvvmViewModel.ViewDataList.SelectMany(p => p.Claims ?? new List<string>()).Distinct().ToList();
        // claims.AddRange(new []{"async","async", "async", "async", "async", "async", "async", "async", "async", "async", "async", "async", "async", "async", "async", "async", "async", "async", "async", "async"});
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

    private async Task FindThem()
    {
        CrudService.MvvmViewModel.ViewDataList.Any(o => o.PooperAlias.Contains(searchString));
        DataListPagingModel.Filter = searchString;
        await CrudService.ShowModelListAsync(DataListPagingModel);
    }

    private async Task FindThemLoaded()
    {

        await CrudService.ShowModelListAsync(DataListPagingModel);
    }
    
    private void FilterDataListOnKeyUp(KeyboardEventArgs obj)
    {
        CrudService.FilterDataListOnClient(DataListPagingModel);
    }

    private void ClickChipHandle(MouseEventArgs arg)
    {
        CrudService.FilterDataListOnClient(DataListPagingModel);
    }
}
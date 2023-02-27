using ClientLibrary.Interfaces;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ClientLibrary.Components.Dialogs;

public partial class PooperFormDialog
{
    [CascadingParameter] MudDialogInstance MudDialog { get; set; }

    [CascadingParameter]
    private IBaseMvvmViewModel<PooperViewModel> ViewModel { get; set; }

    // private void CloseMe()
    // {
    //     // ViewModel.StatusType = StatusTypes.StatusCanceled;
    // }
    //
    void Cancel() => MudDialog.Cancel();

    protected override async Task OnInitializedAsync()
    {
        await Task.CompletedTask;
        await base.OnInitializedAsync();
    }
    
    public void Dispose()
    {
        ViewModel.OnPropertyChanged();
    }
    
}
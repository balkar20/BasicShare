using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ClientLibrary.Components.Dialogs;

public partial class PooperFormDialog
{
    [CascadingParameter] MudDialogInstance? MudDialog { get; set; }

    // private void CloseMe()
    // {
    //     // ViewModel.StatusType = StatusTypes.StatusCanceled;
    // }
    //
    void Cancel() => MudDialog.Cancel();

    // protected override async Task OnInitializedAsync()
    // {
    //     // ViewModel = CrudService.MvvmViewModel;
    //     await Task.CompletedTask;
    // }
}
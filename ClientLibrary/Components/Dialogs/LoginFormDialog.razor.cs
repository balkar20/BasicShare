using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ClientLibrary.Components.Dialogs;

public partial class LoginFormDialog
{
    [Parameter]
    public EventCallback OnClosed { get; set; }
    
    [CascadingParameter] MudDialogInstance MudDialog { get; set; }

    async Task OnClose()
    {
        await OnClosed.InvokeAsync();
    }
    
    async Task Cancel()
    {
        await OnClosed.InvokeAsync();
        MudDialog.Cancel();
    }
}
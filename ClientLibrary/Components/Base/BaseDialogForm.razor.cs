using ClientLibrary.Interfaces;
using IdentityProvider.Shared.Interfaces;
using Microsoft.AspNetCore.Components;

namespace ClientLibrary.Components.Base;

public partial class BaseDialogForm<TModel>  where TModel : IViewModel
{
    // [CascadingParameter] MudDialogInstance MudDialog { get; set; }
    
    public IBaseMvvmViewModel<TModel> ViewModel { get; set; }
    
    [Parameter]
    public EventCallback<bool> HandleErrorSubmitting { get; set; }
    
    
    [Parameter]
    public EventCallback<bool> HandleSuccessSubmitting { get; set; }
    
    
    [Parameter]
    public EventCallback HandleClose { get; set; }
    
    
    [Parameter]
    public RenderFragment ChildContent { get; set; }
    
    [Parameter]
    public TModel Model { get; set; }
    

    async  Task HandleValidSubmit()
    {
        // ViewModel.StatusType = StatusTypes.Success;
        await HandleSuccessSubmitting.InvokeAsync();
    }    

    async  Task HandleErrorSubmit()
    {
        await HandleSuccessSubmitting.InvokeAsync();
    }

    async Task Close()
    {
        await HandleClose.InvokeAsync();
    }
}
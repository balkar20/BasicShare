using BaseClientLibrary.Enums;
using ClientLibrary.Interfaces;
using Core.Transfer;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace ClientLibrary.Components.Forms;

public partial class PooperForm
{
    [Inject]
    public IBaseCrudService<PooperViewModel, BaseResponseResult, PooperViewModel> CrudService{ get; set; }

    
    public IBaseMvvmViewModel<PooperViewModel> ViewModel { get; set; }

    async Task SavePooper()
    {
        var result = await CrudService.UpdateModelAsync();
    }
    
    private void CloseMe()
    {
        ViewModel.StatusType = StatusTypes.StatusCanceled;
    }

    // void Submit() => CloseDialog.InvokeAsync(DialogResult.Ok(true));
    // void Cancel() => MudDialog.Cancel();
    
    private async Task UploadFilesAsync(IBrowserFile file)
    {
        var buffers = new byte[file.Size];
        await file.OpenReadStream().ReadAsync(buffers);
        string imageType = file.ContentType;
        ViewModel.Data.Image = $"data:{imageType};base64,{Convert.ToBase64String(buffers)}";
    }

    protected override async Task OnInitializedAsync()
    {
        ViewModel = CrudService.MvvmViewModel;
        await Task.CompletedTask;
    }

    async Task OnValidSubmit()
    {
        var result = await CrudService.UpdateModelAsync();
    }
}
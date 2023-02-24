using BaseClientLibrary.Enums;
using ClientLibrary.Interfaces;
using Core.Transfer;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace ClientLibrary.Components;

public partial class PooperForm
{
    IBaseCrudService<PooperViewModel, BaseResponseResult, PooperViewModel> _crudService;
    public IBaseMvvmViewModel<PooperViewModel> ViewModel { get; set; }
    
    private string imgHash = string.Empty;

    async Task SavePooper()
    {
        ViewModel.Data.Image = imgHash;
        var result = await _crudService.UpdateModelAsync();
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
        imgHash = $"data:{imageType};base64,{Convert.ToBase64String(buffers)}";
    }

    protected override async Task OnInitializedAsync()
    {
        ViewModel = _crudService.MvvmViewModel;
        await Task.CompletedTask;
    }
}
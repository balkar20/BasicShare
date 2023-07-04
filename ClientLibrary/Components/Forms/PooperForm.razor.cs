
using ClientLibrary.Enums;
using ClientLibrary.Interfaces;
using ClientLibrary.Resources;
using Core.Transfer;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace ClientLibrary.Components.Forms;

public partial class PooperForm: ComponentBase
{
    [Inject]
    public IBaseCrudService<PooperViewModel, BaseResponseResult, PooperViewModel> CrudService{ get; set; }
    
    [Inject]
     IStringLocalizer<LibResource> Localizer{ get; set; }

    
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
        var locTest = Localizer.GetString(ClientResourceConstants.SavePooper);
        SearchedLocation = locTest.SearchedLocation;
        LocTestName  = locTest.Name;
        NotFound  = locTest.ResourceNotFound;
        
        var val = locTest.Value;
        ViewModel = CrudService.MvvmViewModel;
        await Task.CompletedTask;
    }

    public string? SearchedLocation { get; set; }
    public string? LocTestName { get; set; }
    public bool NotFound { get; set; }

    async Task OnValidSubmit()
    {
        var result = await CrudService.UpdateModelAsync();
    }
}
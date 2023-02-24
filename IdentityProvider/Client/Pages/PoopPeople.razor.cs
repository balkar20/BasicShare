using System.ComponentModel;
using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using ClientLibrary.Components;
using ClientLibrary.Interfaces;
using ClientLibrary.Services;
using IdentityProvider.Client.Components;
using IdentityProvider.Client.ViewModels.Inerfaces;
using Microsoft.AspNetCore.Components.Forms;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using System;
using ClientLibrary.Components.Base;
using Core.Transfer;

namespace IdentityProvider.Client.Pages
{
    public partial class PoopPeople
    {
        private string authMessage;
        private string surnameMessage;
        private IEnumerable<Claim> claims = Enumerable.Empty<Claim>();
        
        private string girlName;
        private string girlEmail;
        private int girlAge;
        private string girlCity;
        private bool isOpen = true;

        [Inject]
        IDialogService DialogService { get; set; }

        IBaseMvvmViewModel< PooperViewModel> PooperViewModel { get; set; }    
        
        [Inject]
        IBaseCrudService<PooperViewModel, BaseResponseResult, PooperViewModel> CrudService { get; set; }

        private void OpenDialog(PooperViewModel pooperViewModel)
        {
            PooperViewModel.Data = pooperViewModel;
            
            DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };
            DialogService.Show<EditDialog>("Simple Dialog", closeOnEscapeKey);
        }

        public async Task SetUpPooperClick(MouseEventArgs e)
        {
            await CrudService.UpdateModelAsync();
        }
        
        protected override async Task OnInitializedAsync()
        {
            PooperViewModel = CrudService.MvvmViewModel;
            await CrudService.GetModelListAsync().ConfigureAwait(false);

        }

        // private async Task SetUpPropertyChangedAsync()
        // {
        //     PooperViewModel.PropertyChanged += async (sender, e) => { 
        //         await InvokeAsync(() =>
        //         {
        //             StateHasChanged();
        //         });
        //     };
        // }
        
        // async void OnPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        // {
        //     await InvokeAsync(() =>
        //     {
        //         StateHasChanged();
        //     });
        // }

        // public void Dispose()
        // {
        //     PooperViewModel.PropertyChanged -= OnPropertyChangedHandler;
        // }
    }

}
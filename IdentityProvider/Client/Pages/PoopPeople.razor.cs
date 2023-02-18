using System.ComponentModel;
using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using ClientLibrary.Components;
using ClientLibrary.Interfaces;
using ClientLibrary.Services;
using Core.Transfer;
using IdentityProvider.Client.Components;
using IdentityProvider.Client.ViewModels.Inerfaces;
using Microsoft.AspNetCore.Components.Forms;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;


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
        
        [Inject]
        IBaseMvvmViewModel<string, PooperViewModel> PooperViewModel { get; set; }    
        
        [Inject]
        IBaseCrudService<PooperViewModel, string> CrudService { get; set; }

        private void LoadPhoto(InputFileChangeEventArgs obj)
        {
            throw new NotImplementedException();
        }
        
        private void OpenDialog(PooperViewModel pooperViewModel)
        {
            PooperViewModel.Data = pooperViewModel;
            DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };

            DialogService.Show<EditDialog>("Simple Dialog", closeOnEscapeKey);
        }
        
        private void DeleteUser()
        {

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };
        }
        
        private void Cancel(MouseEventArgs obj)
        {
            Console.WriteLine("Ccancel!");
        }
        
        private void Submit(MouseEventArgs obj)
        {
            Console.WriteLine("Ccancel!");
        }
        
        private void SetUpPooper()
        {
            // MudDialog.
        }
        
        public async Task SetUpPooperClick(MouseEventArgs e)
        {
            Console.WriteLine("Edit!");
            await CrudService.UpdateModelAsync();
            await SetUpPropertyChangedAsync();
        }
        
        protected override async Task OnInitializedAsync()
        {
            ViewModel.IsBusy = true;
             var response = await CrudService.GetModelListAsync();
             if (response.IsSuccess)
             {
                 ViewModel.DataList = response.Data;
             }
             else
             {
                 var messages = new StringBuilder();
                 foreach (var responseError in response.Errors)
                 {
                     messages.AppendLine(responseError);
                 }

                 ViewModel.StatusMessage = messages.ToString();
             }
             
             await SetUpPropertyChangedAsync().ConfigureAwait(false);
             ViewModel.IsBusy = false;
        }

        private async Task SetUpPropertyChangedAsync()
        {
            PooperViewModel.PropertyChanged += async (sender, e) => { 
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            };
        }
        
        async void OnPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        public void Dispose()
        {
            PooperViewModel.PropertyChanged -= OnPropertyChangedHandler;
        }
        
        private async Task GetClaimsPrincipalData()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                authMessage = $"{user.Identity.Name} is authenticated.";
                claims = user.Claims;
                surnameMessage =
                    $"Role: {user.FindFirst(c => c.Type == ClaimTypes.Role)?.Value}";
            }
            else
            {
                authMessage = "The user is NOT authenticated.";
            }
        }
    }

}
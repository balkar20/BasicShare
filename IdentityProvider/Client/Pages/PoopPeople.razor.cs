using System.ComponentModel;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using Core.Transfer;
using IdentityProvider.Client.Components;
using IdentityProvider.Client.ViewModels.Inerfaces;
using Microsoft.AspNetCore.Components.Forms;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;


namespace IdentityProvider.Client.Pages
{
    public partial class PoopPeople
    {
        private string girlName;
        private string girlEmail;
        private int girlAge;
        private string girlCity;
        private bool isOpen = true;
        
        [Inject]
        HttpClient HttpClient { get; set; }
        
        [Inject]
        IDialogService DialogService { get; set; }
        
        [Inject]
        IPooperViewModel PooperViewModel { get; set; }

        private void LoadPhoto(InputFileChangeEventArgs obj)
        {
            throw new NotImplementedException();
        }
        
        private void OpenDialog(PooperViewModel pooperViewModel)
        {
            PooperViewModel.Pooper = pooperViewModel;
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
            await HttpClient.PutAsJsonAsync<PooperViewModel>("api/poopers", ViewModel.Pooper);
            await SetUpPropertyChangedAsync();
        }
        
        protected override async Task OnInitializedAsync()
        {
            ViewModel.IsBusy = true;
             var response = await ViewModel.GetPoopers();
             if (response.IsSuccess)
             {
                 ViewModel.PooperList = response.Data;
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
    }

}
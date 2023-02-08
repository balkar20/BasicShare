using System.ComponentModel;
using System.Net;
using System.Net.Http.Json;
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
        [Inject]
        HttpClient HttpClient { get; set; }
        
        [Inject]
        IDialogService DialogService { get; set; }
        
        [Inject]
        IPooperViewModel PooperViewModel { get; set; }
        
        
        // [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        // static PoopPeople(HttpClient httpClient)
        // {
        //     _httpClient = httpClient;
        // }
        public PoopPeople()
        {
            // HttpClient1 = httpClient;
        }
        // private List<PooperViewModel> PooperlList = new() {new()
        //          {
        //              Id = 1, Name = "VladCoach", AmountOfPoops = 0
        //          },
        //     new()
        //         {
        //             Id = 2, Name = "Drews", AmountOfPoops = 0
        //         }
        // };
        private static List<PooperViewModel> PooperlList = new List<PooperViewModel>();

        private void LoadPhoto(InputFileChangeEventArgs obj)
        {
            throw new NotImplementedException();
        }
        
        private void OpenDialog(PooperViewModel pooperViewModel)
        {
            ViewModel.Pooper = pooperViewModel;
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
        
        public void SetUpPooperClick(MouseEventArgs e)
        {
            // call ToggleMenu or any other method
            Console.WriteLine("Edit!");
        }
        
        protected override async Task OnInitializedAsync()
        {
            ViewModel.PooperList = await HttpClient.GetFromJsonAsync<List<PooperViewModel>>("api/poopers");
            await SetUpPropertyChangedAsync();
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
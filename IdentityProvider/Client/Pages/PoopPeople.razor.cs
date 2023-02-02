using System.Net;
using System.Net.Http.Json;
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
        HttpClient HttpClient1 { get; set; }
        
        [Inject]
        IDialogService DialogService { get; set; }
        
        
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
        
        private void OpenDialog()
        {
            // var options = new DialogOptions { CloseOnEscapeKey = true };
            // DialogService.Show<DialogUsageExample_Dialog>("Simple Dialog", options);
            // CategoryTypes.Dialog.Show<MudDialogInstance>("Custom Options Dialog", options);
            // var options = new DialogOptions { CloseOnEscapeKey = true };
            // DialogService.Show<DialogUsageExample_Dialog>("Simple Dialog", options);
        }
        
        private void DeleteUser()
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Do you really want to delete these records? This process cannot be undone.");
            parameters.Add("ButtonText", "Delete");
            parameters.Add("Color", Color.Error);

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
            PooperlList = await HttpClient1.GetFromJsonAsync<List<PooperViewModel>>("api/poopers");
        }
    }

}
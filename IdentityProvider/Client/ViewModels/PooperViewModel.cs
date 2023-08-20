using System.ComponentModel;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using IdentityProvider.Client.ViewModels.Inerfaces;
using IdentityProvider.Shared;
using Core.Transfer;

namespace IdentityProvider.Client.ViewModels;

public class PooperVM  : INotifyPropertyChanged, IPooperViewModel
{
    private readonly HttpClient _httpClient;
    public PooperVM(HttpClient httpClient)
    {
        _httpClient = httpClient;
        PooperList = new List<UserViewModel>();
    }
    
    private bool isBusy =  false;
    public bool IsBusy
    {
        get => isBusy; 
        set
        {
            isBusy = value; OnPropertyChanged();
        }
    }

    public int Poopers { get; }
    
    public UserViewModel User { get; set; }

    public List<UserViewModel> PooperList { get; set; }

    public string StatusMessage { get; set; }

    
    public event PropertyChangedEventHandler PropertyChanged;
    
    public async Task<BaseResponseResult> SavePooper()
    {
        var result = await _httpClient.PutAsJsonAsync<UserViewModel>("api/poopers", User);
        var respose = await result.Content.ReadFromJsonAsync<BaseResponseResult>();
        if (respose.IsSuccess)
        {
            OnPropertyChanged("Pooper");
        }

        return respose;
    }
    
    public async Task<ResponseResultWithData<List<UserViewModel>>> GetPoopers()
    {
        var response = await _httpClient.GetFromJsonAsync<ResponseResultWithData<List<UserViewModel>>>("api/poopers");
        if (response != null && response.IsSuccess)
        {
            PooperList = response.Data;
            OnPropertyChanged("PooperList");
        }

        return response;
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
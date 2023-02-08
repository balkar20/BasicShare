using System.ComponentModel;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using IdentityProvider.Client.ViewModels.Inerfaces;
using IdentityProvider.Shared;

namespace IdentityProvider.Client.ViewModels;

public class PooperVM  : INotifyPropertyChanged, IPooperViewModel
{
    public PooperVM()
    {
        PooperList = new List<PooperViewModel>();
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
    
    public PooperViewModel Pooper { get; set; }

    public List<PooperViewModel> PooperList { get; set; }
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    public void SavePooper()
    {
        Console.WriteLine("Pooper Saved!");
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
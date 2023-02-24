using System.ComponentModel;
using System.Runtime.CompilerServices;
using BaseClientLibrary.Enums;
using ClientLibrary.Annotations;
using ClientLibrary.Interfaces;
using FluentValidation;
using IdentityProvider.Shared;
using IdentityProvider.Shared.Interfaces;

namespace ClientLibrary.Services;

public  class BaseMvvmViewModel<TData>: IBaseMvvmViewModel<TData> where TData: IViewModel
{

    public event PropertyChangedEventHandler? PropertyChanged;
    public TData Data { get; set; }

    public StatusTypes StatusType{ get; set; }

    public List<TData> DataList { get; set; }

    public string DataApiString { get; set; }

    public string DataListApiString { get; set; }
    
    public string StatusMessage { get; set; }
    
    public bool IsLoading { get; set; }
    
    public bool IsFailed { get; set; }

    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ClientLibrary.Enums;
using ClientLibrary.Interfaces;
using ClientLibrary.Validators;
using Core.Transfer;
using FluentValidation;
using IdentityProvider.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ClientLibrary.Services;

public  class BaseMvvmViewModel<TData>: IBaseMvvmViewModel<TData> where TData: IViewModel, new()
{
    public BaseMvvmViewModel(BaseModelValidator<TData> validator)
    {
        Data = new();
        StatusType = StatusTypes.StatusCanceled;
        Validator = validator;
        
        DataApiString = $"api/{typeof(TData).Name.Replace("ViewModel", "" ).ToLower()}";
        DataListApiString = $"api/{typeof(TData).Name.Replace("ViewModel", "s" ).ToLower()}";
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public TData Data { get; set; }

    public StatusTypes StatusType{ get; set; }

    public List<TData> DataList { get; set; }

    public string DataApiString { get; set; }

    public string DataListApiString { get; set; }
    
    public string StatusMessage { get; set; }
    
    public bool IsLoading { get; set; }
    
    public bool IsFailed { get; set; }
    
    public BaseModelValidator<TData> Validator { get; set; }
    
    public int TotalPages { get; set; }
    
    public int PageSize { get; set; }
    

    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public virtual void ConfigureCrudService<TResponseData>(IServiceCollection services)
    {
        services.AddScoped<
            IBaseCrudService<TData, BaseResponseResult, TResponseData>, 
            BaseCrudService<TData, BaseResponseResult, TResponseData>>();
    }
}
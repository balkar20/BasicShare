using System.ComponentModel;
using System.Runtime.CompilerServices;
using ClientLibrary.Enums;
using ClientLibrary.Interfaces;
using ClientLibrary.Validators;
using Core.Transfer;
using Core.Transfer.Filtering;
using IdentityProvider.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ClientLibrary.Services;

public  class BaseMvvmViewModel<TData>: IBaseMvvmViewModel<TData> where TData: IViewModel, new()
{
    public BaseMvvmViewModel(BaseModelValidator<TData> validator, Func<TData, Filter, bool>? viewDataListFilter = null)
    {
        Data = new();
        StatusType = StatusTypes.StatusCanceled;
        Validator = validator;
        
        DataApiString = $"api/{typeof(TData).Name.Replace("ViewModel", "" ).ToLower()}";
        DataListApiString = $"api/{typeof(TData).Name.Replace("ViewModel", "s" ).ToLower()}";
        CachedDataListDictionary = new Dictionary<int, List<TData>>();
        ViewDataListFilter = viewDataListFilter ?? ((data, s) => false);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public TData Data { get; set; }

    public StatusTypes StatusType{ get; set; }

    public List<TData> ViewDataList { get; set; }
    
    public HashSet<string> DataLabels { get; set; }
    
    public Func<TData, Filter, bool> ViewDataListFilter { get; set; }

    public IDictionary<int, List<TData>> CachedDataListDictionary { get; set; }

    public string DataApiString { get; set; }

    public string DataListApiString { get; set; }
    
    public string StatusMessage { get; set; }
    
    public bool IsLoading { get; set; }
    
    public bool IsFailed { get; set; }
    
    public BaseModelValidator<TData> Validator { get; set; }
    
    public int TotalPages { get; set; }
    public int TotalFilteredPages { get; set; }
    
    public bool IsFiltered { get; set; }

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

    public void SetAndCacheDataList(int page, List<TData> list)
    {
        ViewDataList = list;
        
        if (!CachedDataListDictionary.ContainsKey(page) || !CachedDataListDictionary[page].Any())
        {
            CachedDataListDictionary[page] = list;
        }
    }
}
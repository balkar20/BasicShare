using System.ComponentModel;
using System.Runtime.CompilerServices;
using ClientLibrary.Enums;
using ClientLibrary.Validators;
using Core.Transfer.Filtering;
using IdentityProvider.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ClientLibrary.Interfaces;

public interface IBaseMvvmViewModel<TData>: INotifyPropertyChanged where TData: IViewModel
{
    public TData Data { get; set; }
    
    public StatusTypes StatusType { get; set; }

    public List<TData> ViewDataList { get; set; }

    public HashSet<string> DataLabels { get; set; }

    public Func<TData, Filter, bool> ViewDataListFilter { get; set; }
    public IDictionary<int, List<TData>> CachedDataListDictionary { get; set; }

    public string DataApiString { get; set; }

    public string DataListApiString { get; set; }

    public string StatusMessage { get; set; }

    public bool IsLoading { get; set; }
    
    public bool IsFailed { get; set; }
    
    BaseModelValidator<TData> Validator { get; set; }
    
    int TotalPages { get; set; }
    
    int TotalFilteredPages { get; set; }
    
    bool IsFiltered { get; set; }
    
    int PageSize { get; set; }

    void OnPropertyChanged([CallerMemberName] string propertyName = null);

    void ConfigureCrudService<TResponseData>(IServiceCollection services);

    void SetAndCacheDataList(int page, List<TData> list);
}
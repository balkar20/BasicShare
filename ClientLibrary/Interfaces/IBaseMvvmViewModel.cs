using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientLibrary.Interfaces;

public interface IBaseMvvmViewModel<TContext, TData>: INotifyPropertyChanged
{
    public TContext Context { get; set; }

    public TData Data { get; set; }

    public List<TData> DataList { get; set; }

    public string DataApiString { get; set; }

    public string DataListApiString { get; set; }
    

    public string StatusMessage { get; set; }

    public bool IsBusy { get; set; }

    void OnPropertyChanged([CallerMemberName] string propertyName = null);
}
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ClientLibrary.Annotations;

namespace IdentityProvider.Client.ViewModels;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    private bool _isBusy = false;
    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            SetValue(ref _isBusy, value);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void SetValue<T>(ref T backingFiled, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
        backingFiled = value;
        OnPropertyChanged(propertyName);
    }
    
    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
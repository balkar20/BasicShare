using System.ComponentModel;
using Core.Transfer;
using IdentityProvider.Shared;

namespace IdentityProvider.Client.ViewModels.Inerfaces;

public interface IPooperViewModel
{
    bool IsBusy { get; set; }
    int Poopers { get; }
    UserViewModel User { get; set; }
    List<UserViewModel> PooperList { get; set; }
    
    string StatusMessage { get; set; }

    event PropertyChangedEventHandler PropertyChanged;

    Task<BaseResponseResult> SavePooper();

    Task<ResponseResultWithData<List<UserViewModel>>> GetPoopers();
}
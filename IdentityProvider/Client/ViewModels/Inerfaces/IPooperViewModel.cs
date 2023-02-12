using System.ComponentModel;
using Core.Transfer;
using IdentityProvider.Shared;

namespace IdentityProvider.Client.ViewModels.Inerfaces;

public interface IPooperViewModel
{
    bool IsBusy { get; set; }
    int Poopers { get; }
    PooperViewModel Pooper { get; set; }
    List<PooperViewModel> PooperList { get; set; }

    event PropertyChangedEventHandler PropertyChanged;

    Task<BaseResponseResult> SavePooper();
}
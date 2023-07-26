using Core.Transfer;
using IdentityProvider.Shared.Interfaces;


namespace ClientLibrary.Interfaces;

public interface IBaseCrudService<TModel, TResponseViewModel, TResponseData> 
    where TResponseViewModel: BaseResponseResult
where TModel: IViewModel
{
    IBaseMvvmViewModel<TModel> MvvmViewModel { get; set; }
    ValueTask ShowModelListAsync(DataListPagingModel dataListPagingModel);
    
    Task<ResponseResultWithData<TModel>> GetModelAsync(string id);

    Task<TResponseViewModel> UpdateModelAsync();

    Task<TResponseViewModel> CreateModelAsync(TModel model);

    Task<ResponseResultWithData<TResponseData>> CreateDataAsync();

    bool FilterDataListOnClient(DataListPagingModel dataListPagingModel);
}
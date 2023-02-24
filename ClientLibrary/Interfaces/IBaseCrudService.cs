using Core.Transfer;

namespace ClientLibrary.Interfaces;

public interface IBaseCrudService<TModel, TIdentifier>
{
    IBaseMvvmViewModel<TIdentifier, TModel> BaseMvvmViewModel { get; set; }
    
    Task<ResponseResultWithData<List<TModel>>> GetModelListAsync();
    
    Task<ResponseResultWithData<TModel>> GetModelAsync(TIdentifier id);

    Task<BaseResponseResult> UpdateModelAsync();

    Task<BaseResponseResult> CreateModelAsync(TModel model);
    
    Task<BaseResponseResult> DeleteModelAsync(TIdentifier id);
}
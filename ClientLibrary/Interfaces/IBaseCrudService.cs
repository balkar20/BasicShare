using Core.Transfer;
using FluentValidation.Results;
using IdentityProvider.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ClientLibrary.Interfaces;

public interface IBaseCrudService<TModel, TResponseViewModel, TResponseData> 
    where TResponseViewModel: BaseResponseResult
where TModel: IViewModel
{
    IBaseMvvmViewModel<TModel> MvvmViewModel { get; set; }
    Task<ResponseResultWithData<List<TModel>>> GetModelListAsync(DataListPagingModel dataListPagingModel);
    
    Task<ResponseResultWithData<TModel>> GetModelAsync(string id);

    Task<TResponseViewModel> UpdateModelAsync();

    Task<TResponseViewModel> CreateModelAsync(TModel model);

    Task<ResponseResultWithData<TResponseData>> CreateDataAsync();

    // void ConfigureCrudService(IServiceCollection services);
    
    // Task<ValidationResult> ValidateModelValue(); 
}
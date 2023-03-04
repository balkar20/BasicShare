using System.ComponentModel;
using System.Net.Http.Json;
using BaseClientLibrary.Enums;
using ClientLibrary.Interfaces;
// using System.Net.Http.Json;
using Core.Transfer;
using FluentValidation;
using FluentValidation.Results;
using IdentityProvider.Shared;
using IdentityProvider.Shared.Interfaces;

namespace ClientLibrary.Services;

public class BaseCrudService<TModel, TResponseViewModel, TData> : IBaseCrudService<TModel, TResponseViewModel, TData> 
    where TResponseViewModel: BaseResponseResult
where TModel: IViewModel
{
    #region Fields

    private readonly HttpClient _httpClient;
    
    private readonly AbstractValidator<TModel> _modelValidator;

    #endregion Fields

    #region Properties

    public IBaseMvvmViewModel<TModel> MvvmViewModel { get; set; }

    #endregion Properties

    #region Constructors

    public BaseCrudService(HttpClient httpClient, IBaseMvvmViewModel<TModel> baseMvvmViewModel,AbstractValidator<TModel> modelValidator)
    {
        _httpClient = httpClient;
        this.MvvmViewModel = baseMvvmViewModel;
        _modelValidator = modelValidator;
    }

    #endregion Constructors


    #region PublicMethods

    public virtual async Task<ResponseResultWithData<List<TModel>>> GetModelListAsync()
    {
        MvvmViewModel.StatusType = StatusTypes.Loading;
        var response =
            await _httpClient.GetFromJsonAsync<ResponseResultWithData<List<TModel>>>(MvvmViewModel.DataListApiString);
        return HandleResponseResult(response);
    }

    public virtual async Task<ResponseResultWithData<TModel>> GetModelAsync(string id)
    {
        MvvmViewModel.StatusType = StatusTypes.Loading;
        var response = await _httpClient
            .GetFromJsonAsync<ResponseResultWithData<TModel>>($"{MvvmViewModel.DataApiString}?{id}")
            .ConfigureAwait(false);
        return HandleResponseResult(response);
    }

    public virtual async Task<TResponseViewModel> UpdateModelAsync()
    {
        MvvmViewModel.StatusType = StatusTypes.Loading;
        var result = await _httpClient.PutAsJsonAsync<TModel>(MvvmViewModel.DataApiString, MvvmViewModel.Data);
        var responseResult = await result.Content.ReadFromJsonAsync<TResponseViewModel>();
        return (TResponseViewModel)HandleResponseResult(responseResult);
    }

    public virtual async Task<TResponseViewModel> CreateModelAsync(TModel model)
    {
        MvvmViewModel.StatusType = StatusTypes.Loading;
        var result = await _httpClient.PostAsJsonAsync<TModel>(MvvmViewModel.DataApiString, model);
        var responseResult = await result.Content.ReadFromJsonAsync<TResponseViewModel>();
        return (TResponseViewModel)HandleResponseResult(responseResult);
    }

    public async Task<ResponseResultWithData<TData>> CreateDataAsync()
    {
        MvvmViewModel.StatusType = StatusTypes.Loading;
        var result = await _httpClient.PostAsJsonAsync<TModel>(MvvmViewModel.DataApiString, MvvmViewModel.Data);
        var responseResult = await result.Content.ReadFromJsonAsync<ResponseResultWithData<TData>>();
        return (ResponseResultWithData<TData>)HandleResponseResult(responseResult);
    }

    public virtual async Task<TResponseViewModel> DeleteModelAsync(string id)
    {
        MvvmViewModel.StatusType = StatusTypes.Loading;
        var result = await _httpClient.DeleteFromJsonAsync<TResponseViewModel>($"{MvvmViewModel.DataApiString}?{id}");
        return (TResponseViewModel)HandleResponseResult(result);
    }

    public virtual async Task<ValidationResult> ValidateModelValue()
    {
        return await _modelValidator.ValidateAsync(MvvmViewModel.Data);
    }

    #endregion PublicMethods

    #region Private Methods

    private BaseResponseResult HandleResponseResult(BaseResponseResult responseResult)
    {
        if (responseResult.IsSuccess)
        {
            MvvmViewModel.StatusType = StatusTypes.Success;
            MvvmViewModel.OnPropertyChanged(nameof(MvvmViewModel.Data));
        }
        else
        {
            MvvmViewModel.StatusType = StatusTypes.Error;
        }

        MvvmViewModel.StatusMessage = responseResult.Message;

        return responseResult;
    }

    private ResponseResultWithData<TModel> HandleResponseResult(ResponseResultWithData<TModel> responseResult)
    {
        var result = HandleResponseResult((BaseResponseResult)responseResult);
        if (result.IsSuccess)
        {
            MvvmViewModel.Data = responseResult.Data;
        }

        return responseResult;
    }

    private ResponseResultWithData<List<TModel>> HandleResponseResult(
        ResponseResultWithData<List<TModel>> responseResult)
    {
        var result = HandleResponseResult((BaseResponseResult)responseResult);
        if (result.IsSuccess)
        {
            MvvmViewModel.DataList = responseResult.Data;
        }

        return responseResult;
    }

    #endregion Private Methods
}
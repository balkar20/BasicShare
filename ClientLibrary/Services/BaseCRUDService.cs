using System.Net.Http.Json;
using Blazored.LocalStorage;
using ClientLibrary.Enums;
using ClientLibrary.Interfaces;
using Core.Transfer;
using IdentityProvider.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using Severity = MudBlazor.Severity;

namespace ClientLibrary.Services;

public class BaseCrudService<TModel, TResponseViewModel, TData> : IBaseCrudService<TModel, TResponseViewModel, TData>
    where TResponseViewModel : BaseResponseResult
    where TModel : IViewModel
{
    #region Fields

    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    #endregion Fields

    #region Properties

    public IBaseMvvmViewModel<TModel> MvvmViewModel { get; set; }
    public ISnackbar Snackbar { get; set; }

    #endregion Properties

    #region Constructors

    public BaseCrudService(HttpClient httpClient, IBaseMvvmViewModel<TModel> baseMvvmViewModel, ISnackbar snackbar,
        ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        this.MvvmViewModel = baseMvvmViewModel;
        Snackbar = snackbar;
        _localStorage = localStorage;
    }

    #endregion Constructors


    #region PublicMethods

    public virtual async ValueTask ShowModelListAsync(DataListPagingModel dataListPagingModel)
    {
        var isFindOnClint = FilterDataListOnClient(dataListPagingModel);

        if (isFindOnClint)
        {
            return;
        }

        await SetHttpLanguageHeaderFromLocalStorage();
        MvvmViewModel.StatusType = StatusTypes.Loading;

        var url = dataListPagingModel.GetRoutingUrl(MvvmViewModel.DataListApiString);
        var response = await _httpClient.GetFromJsonAsync<ResponseResultWithData<List<TModel>>>(url);
        if (response != null) HandleResponseResult(response, dataListPagingModel);
    }

    public virtual async Task<ResponseResultWithData<TModel>> GetModelAsync(string id)
    {
        await SetHttpLanguageHeaderFromLocalStorage();
        MvvmViewModel.StatusType = StatusTypes.Loading;
        var response = await _httpClient
            .GetFromJsonAsync<ResponseResultWithData<TModel>>($"{MvvmViewModel.DataApiString}?{id}")
            .ConfigureAwait(false);
        return HandleResponseResult(response);
    }

    public virtual async Task<TResponseViewModel> UpdateModelAsync()
    {
        await SetHttpLanguageHeaderFromLocalStorage();
        MvvmViewModel.StatusType = StatusTypes.Loading;
        var result = await _httpClient.PutAsJsonAsync<TModel>(MvvmViewModel.DataApiString, MvvmViewModel.Data);
        var responseResult = await result.Content.ReadFromJsonAsync<TResponseViewModel>();
        return (TResponseViewModel)HandleResponseResult(responseResult);
    }

    public virtual async Task<TResponseViewModel> CreateModelAsync(TModel model)
    {
        await SetHttpLanguageHeaderFromLocalStorage();
        MvvmViewModel.StatusType = StatusTypes.Loading;
        var result = await _httpClient.PostAsJsonAsync<TModel>(MvvmViewModel.DataApiString, model);
        var responseResult = await result.Content.ReadFromJsonAsync<TResponseViewModel>();
        return (TResponseViewModel)HandleResponseResult(responseResult);
    }

    public async Task<ResponseResultWithData<TData>> CreateDataAsync()
    {
        await SetHttpLanguageHeaderFromLocalStorage();
        MvvmViewModel.StatusType = StatusTypes.Loading;
        var result = await _httpClient.PostAsJsonAsync<TModel>(MvvmViewModel.DataApiString, MvvmViewModel.Data);
        var responseResult = await result.Content.ReadFromJsonAsync<ResponseResultWithData<TData>>();
        return (ResponseResultWithData<TData>)HandleResponseResult(responseResult);
    }

    public virtual async Task<TResponseViewModel> DeleteModelAsync(string id)
    {
        await SetHttpLanguageHeaderFromLocalStorage();
        MvvmViewModel.StatusType = StatusTypes.Loading;
        var result = await _httpClient.DeleteFromJsonAsync<TResponseViewModel>($"{MvvmViewModel.DataApiString}?{id}");
        return (TResponseViewModel)HandleResponseResult(result);
    }

    public virtual void ConfigureCrudService<TResponseData>(IServiceCollection services)
    {
        services.AddScoped<
            IBaseCrudService<TModel, BaseResponseResult, TResponseData>,
            BaseCrudService<TModel, BaseResponseResult, TResponseData>>();
    }

    #endregion PublicMethods

    #region Private Methods

    private BaseResponseResult HandleResponseResult(BaseResponseResult responseResult)
    {
        if (responseResult.IsSuccess)
        {
            MvvmViewModel.StatusType = StatusTypes.Success;
            MvvmViewModel.OnPropertyChanged(nameof(MvvmViewModel.StatusType));
            MvvmViewModel.OnPropertyChanged(nameof(MvvmViewModel.Data));
            MvvmViewModel.OnPropertyChanged(nameof(MvvmViewModel.ViewDataList));
            Snackbar.Add(
                string.IsNullOrWhiteSpace(responseResult.Message) ? "Request was successful" : responseResult.Message,
                Severity.Success);
        }
        else
        {
            Snackbar.Add(
                string.IsNullOrWhiteSpace(responseResult.Message) ? "Request was failed" : responseResult.Message,
                Severity.Error);

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

    private void HandleResponseResult(
        ResponseResultWithData<List<TModel>> responseResult, DataListPagingModel dataListPagingModel)
    {
        var result = HandleResponseResult((BaseResponseResult)responseResult);
        if (result.IsSuccess)
        {
            MvvmViewModel.SetAndCacheDataList(dataListPagingModel.CurrentPage, responseResult.Data);
            if (!string.IsNullOrWhiteSpace(dataListPagingModel.Filter))
            {
                MvvmViewModel.TotalFilteredPages = responseResult.Count >=  0 ? (int)Math.Ceiling((double)responseResult.Count / MvvmViewModel.PageSize) : 1;
                MvvmViewModel.IsFiltered= true;
                return;
            }
            MvvmViewModel.TotalPages = (int)Math.Ceiling((double)responseResult.Count / MvvmViewModel.PageSize);
        }
    }

    public bool FilterDataListOnClient(DataListPagingModel dataListPagingModel)
    {
        if (!MvvmViewModel.CachedDataListDictionary.Any() || !MvvmViewModel.CachedDataListDictionary.ContainsKey(dataListPagingModel.CurrentPage))
        {
            return false;
        }
        
        if (string.IsNullOrWhiteSpace(dataListPagingModel.Filter))
        {
            MvvmViewModel.IsFiltered = false;
            MvvmViewModel.ViewDataList = MvvmViewModel.CachedDataListDictionary[dataListPagingModel.CurrentPage];
        }
        else
        {
            MvvmViewModel.ViewDataList = MvvmViewModel.CachedDataListDictionary.Values
                .SelectMany(x => x.Where(y => MvvmViewModel.ViewDataListFilter(y, dataListPagingModel.Filter)))
                .ToList();
            MvvmViewModel.IsFiltered = true;
        }

        var isFoundedOnClient = MvvmViewModel.ViewDataList.Any();

        if (isFoundedOnClient)
        {
            MvvmViewModel.TotalFilteredPages =
                (int)Math.Ceiling((double)MvvmViewModel.ViewDataList.Count / MvvmViewModel.PageSize);
            MvvmViewModel.OnPropertyChanged(nameof(MvvmViewModel.ViewDataList));
        }
        else
        {
            MvvmViewModel.TotalFilteredPages = 1;
        }
        
        
        return isFoundedOnClient;
    }

    private int GetTotalCachedDataListCount()
    {
        return MvvmViewModel.CachedDataListDictionary.Values.Sum(x => x.Count);
    }

    private async Task SetHttpLanguageHeaderFromLocalStorage()
    {
        if (await _localStorage.ContainKeyAsync(ClientConstants.LanguageLocalStorageKey))
        {
            var lang = await _localStorage.GetItemAsStringAsync(ClientConstants.LanguageLocalStorageKey);
            _httpClient.DefaultRequestHeaders.Add(ClientConstants.LanguageHttpHeaderKey, lang);
        }
    }

    #endregion Private Methods
}
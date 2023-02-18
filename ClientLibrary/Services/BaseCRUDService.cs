using System.ComponentModel;
using System.Net.Http.Json;
using ClientLibrary.Interfaces;
// using System.Net.Http.Json;
using Core.Transfer;

namespace ClientLibrary.Services;

public class BaseCrudService<TModel, TContext> : IBaseCrudService<TModel, TContext>
{
    private readonly HttpClient _httpClient;
    public  IBaseMvvmViewModel<TContext, TModel> BaseMvvmViewModel { get; set; }
    

    public BaseCrudService(HttpClient httpClient, IBaseMvvmViewModel<TContext, TModel> baseMvvmViewModel)
    {
        _httpClient = httpClient;
        this.BaseMvvmViewModel = baseMvvmViewModel;
    }

    public async Task<ResponseResultWithData<List<TModel>>> GetModelListAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ResponseResultWithData<List<TModel>>>(BaseMvvmViewModel.DataListApiString).ConfigureAwait(false);
        if (response != null && response.IsSuccess)
        {
            BaseMvvmViewModel.DataList = response.Data;
            BaseMvvmViewModel.OnPropertyChanged(nameof(BaseMvvmViewModel.DataList));
        }
        
        return response;
    }

    public async Task<ResponseResultWithData<TModel>> GetModelAsync(TContext id)
    {
        var response = await _httpClient.GetFromJsonAsync<ResponseResultWithData<TModel>>($"{BaseMvvmViewModel.DataApiString}?{id}").ConfigureAwait(false);
        if (response != null && response.IsSuccess)
        {
            BaseMvvmViewModel.Data = response.Data;
            BaseMvvmViewModel.OnPropertyChanged(nameof(BaseMvvmViewModel.Data));
        }
        
        return response;
    }

    public async Task<BaseResponseResult> UpdateModelAsync()
    {
        var result = await _httpClient.PutAsJsonAsync<TModel>(BaseMvvmViewModel.DataApiString, BaseMvvmViewModel.Data);
        var respose = await result.Content.ReadFromJsonAsync<BaseResponseResult>();
        if (respose.IsSuccess)
        {
            BaseMvvmViewModel.OnPropertyChanged(nameof(BaseMvvmViewModel.Data));
        }

        return respose;
    }

    public async Task<BaseResponseResult> CreateModelAsync(TModel model)
    {
        var result = await _httpClient.PostAsJsonAsync<TModel>(BaseMvvmViewModel.DataApiString, model);
        var respose = await result.Content.ReadFromJsonAsync<BaseResponseResult>();
        if (respose.IsSuccess)
        {
            BaseMvvmViewModel.OnPropertyChanged(nameof(BaseMvvmViewModel.Data));
        }

        return respose;
    }

    public async Task<BaseResponseResult> DeleteModelAsync(TContext id)
    {
        var result = await _httpClient.DeleteFromJsonAsync<BaseResponseResult>($"{BaseMvvmViewModel.DataApiString}?{id}");
        if (result.IsSuccess)
        {
            BaseMvvmViewModel.OnPropertyChanged(nameof(BaseMvvmViewModel.Data));
        }

        return result;
    }
}
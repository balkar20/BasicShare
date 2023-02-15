namespace Core.Transfer;

public class ResponseResultWithData<TData>: BaseResponseResult
{
    public TData? Data { get; set; }
}
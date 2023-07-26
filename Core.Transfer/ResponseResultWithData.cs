namespace Core.Transfer;

public class ResponseResultWithData<TData>: BaseResponseResult
{
    public TData? Data { get; set; }
    
    public List<string>? DataLabels { get; set; }

    public int Count { get; set; } = 1;
}
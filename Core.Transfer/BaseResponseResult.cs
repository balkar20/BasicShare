namespace Core.Transfer;

public class BaseResponseResult
{
    public BaseResponseResult()
    {
        Errors = new List<string>();
    }

    public IList<string> Errors { get; set; }

    public bool IsSuccess { get; set; }
}
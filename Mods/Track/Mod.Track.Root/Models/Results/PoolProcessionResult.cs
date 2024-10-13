using ParallelProcessing.Models.Results.Procession.Abstractions;

namespace ParallelProcessing.Models.Results;

public class PoolProcessionResult:IProcessionResult
{
    public bool IsSucceed { get; set; }
    
    public string ItemId { get; set; }
}
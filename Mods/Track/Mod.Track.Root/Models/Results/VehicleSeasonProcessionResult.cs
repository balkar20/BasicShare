using ParallelProcessing.Models.Results.Procession.Abstractions;

namespace ParallelProcessing.Models.Results;

public class VehicleSeasonProcessionResult: IProcessionResult
{
    public bool IsSucceed { get; set; }
    
    public string ItemId { get; set; }

    public string Message { get; set; }
    
    public int Data { get; set; }
}
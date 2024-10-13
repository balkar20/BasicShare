namespace ParallelProcessing.Models.Results.Procession.Abstractions;

public interface IProcessionResult
{
    public bool IsSucceed { get; set; }
    
    public string ItemId { get; set; }
}
using ParallelProcessing.Models.Results.Analyse.Abstractions;

namespace ParallelProcessing.Models.Results.Analyse;

public class DangerAnalyseResult: IAnalysingResult
{
    public string Message { get; set; }
}
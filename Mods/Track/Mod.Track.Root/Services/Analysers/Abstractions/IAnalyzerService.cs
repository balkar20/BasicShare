using ParallelProcessing.Models.Items.Analysing;
using ParallelProcessing.Models.Results.Analyse.Abstractions;

namespace ParallelProcessing.Services.Analysers.Abstractions;

public interface IAnalyzerService
{
    Task<IAnalysingResult> Analyse(AnalysingItem analysingItem);
}
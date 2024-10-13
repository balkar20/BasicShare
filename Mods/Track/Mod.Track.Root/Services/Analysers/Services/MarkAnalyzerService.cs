using ParallelProcessing.Configuration;
using ParallelProcessing.Models.Items.Analysing;
using ParallelProcessing.Models.Results.Analyse;
using ParallelProcessing.Models.Results.Analyse.Abstractions;
using ParallelProcessing.Services.Analysers.Abstractions;

namespace ParallelProcessing.Services.Analysers.Services;

class MarkAnalyzerService(VehicleMarkAnalyseConfig vehicleMarkAnalyseConfig)
    : IAnalyzerService
{
    private TimeSpan timeForAnalyse => vehicleMarkAnalyseConfig.TimeForAnalyse;

    public async Task<IAnalysingResult> Analyse(AnalysingItem analysingItem)
    {
        await Task.Delay(timeForAnalyse);
        return new MarkAnalyseResult
        {
            Message = $"I was Delayed for {timeForAnalyse} by Analysing Item mark: ItemId={analysingItem.ItemId} with Mark="
        };
    }
}
using ParallelProcessing.Configuration;
using ParallelProcessing.Models.Items.Analysing;
using ParallelProcessing.Models.Results.Analyse;
using ParallelProcessing.Models.Results.Analyse.Abstractions;
using ParallelProcessing.Services.Analysers.Abstractions;

namespace ParallelProcessing.Services.Analysers.Services;

class ColorAnalyzerService(VehicleColorAnalyseConfig vehicleColorAnalyseConfig) : IAnalyzerService
{
    private  TimeSpan timeForAnalyse = vehicleColorAnalyseConfig.TimeForAnalyse;

    public async Task<IAnalysingResult> Analyse(AnalysingItem analysingItem)
    {
        await Task.Delay(timeForAnalyse);
        return new ColorAnalyseResult
        {
            Message = $"I was Delayed for {timeForAnalyse} by Analysing Item color: ItemId={analysingItem.ItemId} with Color="
        };
    }
}
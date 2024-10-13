using ParallelProcessing.Configuration;
using ParallelProcessing.Models.Items.Analysing;
using ParallelProcessing.Models.Results.Analyse;
using ParallelProcessing.Models.Results.Analyse.Abstractions;
using ParallelProcessing.Services.Analysers.Abstractions;

namespace ParallelProcessing.Services.Analysers.Services;

class SeasonAnalyzerService(VehicleSeasonAnalyseConfig vehicleSeasonAnalyseConfig) : IAnalyzerService
{
    private  TimeSpan timeForAnalyse = vehicleSeasonAnalyseConfig.TimeForAnalyse;

    public async Task<IAnalysingResult> Analyse(AnalysingItem analysingItem)
    {
        await Task.Delay(timeForAnalyse);
        return new SeasonAnalyseResult
        {
            Message = $"I was Delayed for {timeForAnalyse} by Analysing Item Season: Number={analysingItem.ItemId} with Season=...."
        };
    }
}
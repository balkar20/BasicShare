using AutoMapper;
using ParallelProcessing.Models;
using ParallelProcessing.Models.Items.Analysing;
using ParallelProcessing.Models.Results;
using ParallelProcessing.Models.Results.Procession.Abstractions;
using ParallelProcessing.Processors.Abstractions;
using ParallelProcessing.Services;
using ParallelProcessing.Services.Analysers.Abstractions;
using ParallelProcessing.Services.Events.Abstractions;
using ParallelProcessing.Services.Events.Data.Enums;

namespace ParallelProcessing.Processors;

public class VehicleMarkProcessor
    (IProcessingItemsStorageServiceRepository<string, Track, VehicleMarkProcessionResult> processingItemsStorageServiceRepository,
        IAnalyzerService analyzerService,
        IMapper mapper,
        IEventLoggingService loggingService, 
        string processorName)
    : ProgressiveProcessor<Track, VehicleMarkProcessionResult>(loggingService, processorName)
{
    protected override async Task<IProcessionResult> ProcessLogic(Track inputData)
    {
        // var resultOfRoot = await processingItemsStorageServiceRepository.GetProcessingItemResult(inputData.ItemId);
        //
        // var isSucceed = resultOfRoot.IsSucceed;
        var analysingItem = mapper.Map<TypeAnalysingItem>(inputData);
        await WorkWithDependentData(inputData.ItemId);
        var typeAnaliseResult = await analyzerService.Analyse(analysingItem);
        // var typeProcessionResult = 
        var result =  mapper.Map<VehicleMarkProcessionResult>(typeAnaliseResult);
        // sharedMemoryService.VehicleMarkProcessResultDictionary.Add(inputData.ItemId, result);
        await loggingService.Log($"{ProcessorName} + time {DateTime.Now}", EventLoggingTypes.ProcessedProcessor);
        return result;
    }

    protected override async Task SetProcessionResult(VehicleMarkProcessionResult result)
    {
        await processingItemsStorageServiceRepository.CreateProcessingItemResult(result);
    }

    private async Task WorkWithDependentData(string trackId)
    {
         // // sharedMemoryService.VehicleColorStatisticsProcessResultDictionary.TryGetValue(trackId, out VehicleColorProcessionResult dependentData);
         // Console.WriteLine($"DependentDta(VehicleColorStatistics) Message: {dependentData.Message}");
    }
}
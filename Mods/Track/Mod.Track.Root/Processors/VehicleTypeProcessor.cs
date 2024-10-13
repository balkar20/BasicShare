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

public class VehicleTypeProcessor
    (IProcessingItemsStorageServiceRepository<string, Track, VehicleTypeProcessionResult> processingItemsStorageServiceRepository,
    IAnalyzerService analyzerService,
    IMapper mapper,
    IEventLoggingService loggingService, 
    string processorName)
    : ProgressiveProcessor<Track, VehicleTypeProcessionResult>(loggingService, processorName)
{
    protected override async Task<IProcessionResult> ProcessLogic(Track inputData)
    {
        //But what if roots a lot?
        var resultOfRoot = await processingItemsStorageServiceRepository.GetProcessingItemResult(inputData.ItemId);
        
        //Here we need some aggregated procession result
        // VehicleTypeProcessionResult r = resultOfRoot;
        
        //Work with resultOf Root further......
     
        var analysingItem = mapper.Map<TypeAnalysingItem>(inputData);
        var typeAnaliseResult = await analyzerService.Analyse(analysingItem);
        var typeProcessionResult = mapper.Map<VehicleTypeProcessionResult>(typeAnaliseResult);
        await loggingService.Log($"{ProcessorName} + time {DateTime.Now}", EventLoggingTypes.ProcessedProcessor);
        return typeProcessionResult;
    }

    protected override async Task SetProcessionResult(VehicleTypeProcessionResult result)
    {
        await processingItemsStorageServiceRepository.CreateProcessingItemResult(result);
    }
}
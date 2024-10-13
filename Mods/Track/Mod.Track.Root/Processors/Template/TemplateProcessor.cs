using ParallelProcessing.Models.Items.Base;
using ParallelProcessing.Models.Results.Procession.Abstractions;
using ParallelProcessing.Processors.Abstractions;
using ParallelProcessing.Services.Events.Abstractions;
using ParallelProcessing.Services.Events.Data.Enums;

namespace ParallelProcessing.Processors.Template;

public class TemplateProcessor<TInput, TProcessionResult>(
    IEventLoggingService? loggingService,
    string processorName,
    Func<TInput, Task<TProcessionResult>> processLogic)
    : ProgressiveProcessor<TInput, TProcessionResult>(loggingService, processorName)
    where TInput : ApplicationItem<string>
    where TProcessionResult : IProcessionResult
{
    protected override async Task<IProcessionResult> ProcessLogic(TInput inputData)
    {
        var result =  await processLogic(inputData);
        await loggingService.Log($"{ProcessorName} + time {DateTime.Now}", EventLoggingTypes.ProcessedProcessor);
        return result;
    }

    protected override Task SetProcessionResult(TProcessionResult result)
    {
        return Task.CompletedTask;
    }
}
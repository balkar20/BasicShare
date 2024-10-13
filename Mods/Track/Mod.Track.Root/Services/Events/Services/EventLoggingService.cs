using ParallelProcessing.Models.Results.Procession.Abstractions;
using Serilog;
using ParallelProcessing.Services.Events.Abstractions;
using ParallelProcessing.Services.Events.Data.Enums;

namespace ParallelProcessing.Services.Events.Services;

public class EventLoggingService: IEventLoggingService
{
    private readonly ILogger _logger;

    public EventLoggingService(ILogger logger)
    {
        _logger = logger;
    }

    public async Task Log(string eventDataString, EventLoggingTypes type, string additional = "")
    {
        var hasDepRoot = "- has dependent root to execute: ";
        var message = type switch
        {
            EventLoggingTypes.ProcessedProcessor => $"ProcessedProcessor :{eventDataString}",
            EventLoggingTypes.CallMethodInProcessor => $"CallMethodInProcessor Message with String :{eventDataString}",
            EventLoggingTypes.CallMethodInProcessorWithCondition => $"CallMethodInProcessorWithCondition Message with String :{eventDataString} and condition:{additional}",
            EventLoggingTypes.CallMethodInProcessorWithCompletedDependant => $"CallMethodInProcessorWithCompletedDependant  with thisName :{eventDataString} and DeperndantName:{additional}",
            EventLoggingTypes.HandlingEvent => $"HandlingEvent Message with String Of  :{eventDataString}, processor called = {additional}",
            EventLoggingTypes.RaisingEvent => $"RaisingEvent Message with String :{eventDataString}",
            EventLoggingTypes.ProcessionInformation => $"ProcessionInformation Message with String :{eventDataString}",
            EventLoggingTypes.SubscribingToEvent => $"SubscribingToEvent  with Name :{eventDataString} and ProcessorName: {additional}",
            EventLoggingTypes.ThreadIdLogging => $"ThreadId :{eventDataString} for Processor : {additional}",
            EventLoggingTypes.ExceptionKindEvent => $"ExceptionKindEvent :{eventDataString} for Processor : {additional}",
            EventLoggingTypes.SemaphoreAcquired => $"SemaphoreAcquired with AquireId:{eventDataString}, {(string.IsNullOrWhiteSpace(additional) ? string.Empty : (hasDepRoot + additional))}",
            EventLoggingTypes.SemaphoreReleased => $"SemaphoreReleased for Processor:{eventDataString}, Execution name: {additional}",
            EventLoggingTypes.TotalProcessionTimeLogging => $"\"!!!!!!!!!!!!!!!Total Time :{eventDataString} SECONDS.!!!!!!!!!!!!!!!!!\"\nCompletion time: {DateTime.Now}",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
        _logger.Information(message);
    }

    public async Task SendResult(IProcessionResult processionResult)
    {
        var hasDepRoot = "- has dependent root to execute: ";
        
        _logger.Information($"Result was Sended");
    }
}
namespace ParallelProcessing.Services.Events.Data.Enums;

public enum EventLoggingTypes
{
    ProcessedProcessor,
    CallMethodInProcessor,
    CallMethodInProcessorWithCondition,
    CallMethodInProcessorWithCompletedDependant,
    HandlingEvent,
    RaisingEvent,
    ProcessionInformation,
    SubscribingToEvent,
    ThreadIdLogging,
    ExceptionKindEvent,
    SemaphoreAcquired,
    SemaphoreReleased,
    TotalProcessionTimeLogging
}
using ParallelProcessing.Processors.Abstractions;

namespace ParallelProcessing.Models.ProcessingLog;

public class ProcessionInfo
{
    public string ProcessorName { get; set; }
    public string ProcessorType { get; set; }
    public string NextDependentProcessorName { get; set; }
}
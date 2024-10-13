using ParallelProcessing.Exceptions.Abstractions;
using ParallelProcessing.Models.Items.Processing;

namespace ParallelProcessing.Exceptions;

public class ProcessingItemCreationException: ProcessingException
{
    public ProcessingItemCreationException(ProcessingItem analysingItem) : base(analysingItem)
    {
    }
}
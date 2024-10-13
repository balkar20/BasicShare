using ParallelProcessing.Models.Items.Processing;

namespace ParallelProcessing.Exceptions.Abstractions;

public abstract class ProcessingException: ApplicationException
{
    public ProcessingException(ProcessingItem analysingItem)
    {
        base.Data.Add(analysingItem.ItemId, analysingItem);
    }
    
}
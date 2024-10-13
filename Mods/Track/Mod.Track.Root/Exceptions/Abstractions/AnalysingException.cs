using ParallelProcessing.Models.Items.Analysing;

namespace ParallelProcessing.Exceptions.Abstractions;

public abstract class AnalysingException: ApplicationException
{
    public AnalysingException(AnalysingItem analysingItem)
    {
        base.Data.Add(analysingItem.ItemId, analysingItem);
    }
    
}
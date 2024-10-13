using ParallelProcessing.Exceptions.Abstractions;
using ParallelProcessing.Models.Items.Analysing;

namespace ParallelProcessing.Exceptions;

public class AnalysingItemCreationException: AnalysingException
{
    public AnalysingItemCreationException(AnalysingItem analysingItem) : base(analysingItem)
    {
    }
}
using ParallelProcessing.Exceptions.Abstractions;
using ParallelProcessing.Models.Results.Procession.Abstractions;

namespace ParallelProcessing.Exceptions;

public class ProcessingItemResultCreationException: ProcessionResultException
{
    public ProcessingItemResultCreationException(IProcessionResult analysingItem) : base(analysingItem)
    {
    }
}
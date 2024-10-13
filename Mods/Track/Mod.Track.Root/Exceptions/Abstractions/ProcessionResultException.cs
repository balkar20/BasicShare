using ParallelProcessing.Models.Results.Procession.Abstractions;

namespace ParallelProcessing.Exceptions.Abstractions;

public abstract class ProcessionResultException: ApplicationException
{
    public ProcessionResultException(IProcessionResult analysingItem)
    {
        base.Data.Add(analysingItem.IsSucceed, analysingItem);
    }
    
}
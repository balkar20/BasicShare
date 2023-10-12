using MassTransit;

namespace MassTransitBase;

public interface IBaseMessage: CorrelatedBy<Guid>
{
    
}
using MassTransit;

namespace MassTransitBase.Messages;

public interface IBaseMessage: CorrelatedBy<Guid>
{
    
}
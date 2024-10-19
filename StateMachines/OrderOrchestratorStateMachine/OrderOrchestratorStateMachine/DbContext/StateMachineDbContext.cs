using MassTransit;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SagaOrchestrationStateMachine.StateInstances;

namespace OrderOrchestratorStateMachine.DbContext;

public class StateMachineDbContext : SagaDbContext
{
    public StateMachineDbContext(DbContextOptions<StateMachineDbContext> options)
        : base(options)
    {
    }

    protected override IEnumerable<ISagaClassMap> Configurations
    {
        get { yield return new OrderStateInstanceMap(); }
    }
}

// Mapping for Entity Framework
public class OrderStateInstanceMap : SagaClassMap<OrderStateInstance>
{
    protected override void Configure(EntityTypeBuilder<OrderStateInstance> entity, ModelBuilder model)
    {
        entity.Property(x => x.CurrentState).HasMaxLength(64);
        entity.Property(x => x.CorrelationId);
        entity.Property(x => x.OrderId);
        entity.Property(x => x.CustomerId);
        entity.Property(x => x.CreatedDate);
        entity.Property(x => x.TotalPrice);
    }
}
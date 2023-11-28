using Serilog;
using System.Reflection;
using System.Runtime.CompilerServices;
using EventBus.Constants;
using Microsoft.Extensions.Hosting;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderOrchestratorStateMachine;
using SagaOrchestrationStateMachine.DbContext;
using SagaOrchestrationStateMachine.StateInstances;
using SagaOrchestrationStateMachine.StateMachines;

[assembly:InternalsVisibleTo("EventIntegrationTest")]
var defaultBuilder = Host.CreateDefaultBuilder(args);
defaultBuilder.ConfigureServices((hostContext, services) =>
    {
        services.AddMassTransit(cfg =>
        {
            cfg.AddSagaStateMachine<OrderStateMachine, OrderStateInstance>().EntityFrameworkRepository(opt =>
            {
                opt.AddDbContext<DbContext, StateMachineDbContext>((provider, builder) =>
                {
                    builder.UseNpgsql(hostContext.Configuration.GetConnectionString("DefaultConnection"),
                        m => { m.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name); });
                });

                opt.ConcurrencyMode = ConcurrencyMode.Optimistic;
            });

            cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(configure =>
            {
                configure.Host("localhost", host =>
                {
                    host.Username("guest");
                    host.Password("guest");
                });

                configure.ReceiveEndpoint(QueuesConsts.CreateOrderMessageQueueName, e => { e.ConfigureSaga<OrderStateInstance>(provider); });
            }));
        });

        services.AddDbContext<StateMachineDbContext>(options =>
            options.UseNpgsql(hostContext.Configuration.GetConnectionString("DefaultConnection")));

        // services.AddHostedService<Worker>();
    });
defaultBuilder.UseSerilog();
IHost host = defaultBuilder.Build();

using (var scope = host.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var orderDbContext = serviceProvider.GetRequiredService<StateMachineDbContext>();
    orderDbContext.Database.Migrate();
}

host.Run();

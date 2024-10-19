using System.Reflection;
using EventBus.Constants;
using MassTransit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderOrchestratorStateMachine.DbContext;
using SagaOrchestrationStateMachine.StateInstances;
using SagaOrchestrationStateMachine.StateMachines;
using Serilog;

namespace EventIntegrationTest;

internal class TestMassTransitApplication: WebApplicationFactory<Program>
{
    private readonly MockServices _mockServices;
    
    private readonly Dictionary<Type, object> TypeImplementaitionDictionary;
    
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices((hostContext, services) =>
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

            //services.AddHostedService<Worker>();
        });



        var host = base.CreateHost(builder);
        
        
        return host;
    }

}
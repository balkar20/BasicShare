using System.Net.Http.Json;
using System.Text;
using Core.Base.Output;
using Mod.Order.Models;

using Moq;
using System.Text.Json;
using AutoMapper;
using Core.Transfer;
using Data.Base.Objects;
using EventBus.Constants;
using EventBus.Messages;
using EventBus.Messages.Interfaces;
using MassTransit;
using MassTransit.Testing;
using MassTransitBase;
using Microsoft.Extensions.DependencyInjection;
using Mod.Order.EventData.Events;
using SagaOrchestrationStateMachine.StateInstances;
using SagaOrchestrationStateMachine.StateMachines;

// using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace EventIntegrationTest.Tests
{
    public class OrderApiTest
    {
        private readonly TestOrderApiApplication _testOrderApiApplication;
        private readonly MockServices _mockServices;
        public readonly HttpClient _orderApiClient;
        public readonly HttpClient _massTransitApiClient;
        public OrderApiTest()
        {
            _mockServices = new MockServices();
            _testOrderApiApplication = new TestOrderApiApplication(_mockServices);
 
            _orderApiClient = _testOrderApiApplication.CreateClient();
        }

        [Fact]
        public async Task StateMachine()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                
                cfg.CreateMap<CreateOrderMessage, OrderCreatedEvent>()
                    .ForMember(x=> x.Id, 
                        opt => 
                            opt.MapFrom(src => src.OrderId))
                    .ForMember(x=> x.CustomerId, 
                        opt => 
                            opt.MapFrom(src => src.CustomerId))
                    .ReverseMap();
                cfg.CreateMap<EventObject, IBaseSagaMessage>()
                    .Include<OrderCreatedEvent, CreateOrderMessage>().ReverseMap();
                cfg.CreateMap<EventObject, ICreateOrderMessage>()
                    .Include<OrderCreatedEvent, CreateOrderMessage>().ReverseMap();
            });
            
            await using var provider = new ServiceCollection()
                .AddMassTransitTestHarness(cfg =>
                {
                    cfg.AddSagaStateMachine<OrderStateMachine, OrderStateInstance>();
                    cfg.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host("localhost", host =>
                        {
                            host.Username("guest");
                            host.Password("guest");
                        });
                        cfg.ReceiveEndpoint(QueuesConsts.CreateOrderMessageQueueName, (IRabbitMqReceiveEndpointConfigurator e) => { e.ConfigureSaga<OrderStateInstance>(context); });

                        // cfg.ReceiveEndpoint(QueuesConsts.CreateOrderMessageQueueName, e => { e.ConfigureSaga<OrderStateInstance>(provider); });

                    });
                })
                .BuildServiceProvider(true);
            
            var harness = provider.GetRequiredService<ITestHarness>();
            await harness.Start();
            
            await harness.Bus.Publish(new CreateOrderMessage
            {
                OrderId = Guid.NewGuid(),
                CustomerId = Guid.NewGuid().ToString(),
                PaymentAccountId = Guid.NewGuid().ToString(),
                TotalPrice = (new Random()).Next(1, 100000),
                OrderItemList = new()
            });
            
            var orderPostDataModel = Randomizer.CreateRandomOrderModel();
            var json = JsonSerializer.Serialize(orderPostDataModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _orderApiClient.PostAsync("api/orders", content);
            var jsonResult =
                await response.Content.ReadFromJsonAsync<BaseResponseResult>();

            //Assert
            // var sagaHarness = harness.GetSagaStateMachineHarness<OrderStateMachine, OrderStateInstance>();
            // var isSent = await harness.Sent.Any<ICreateOrderMessage>();
            // sagaHarness.c
            // sagaHarness.StateMachine.GetState("");
            // var instance = sagaHarness.Created.ContainsInState(orderPostDataModel., sagaHarness.StateMachine, sagaHarness.StateMachine.Submitted);
            Assert.True(await harness.Sent.Any<ICreateOrderMessage>());
            // Assert.True(await harness.con);
            Assert.NotNull(jsonResult);
            Assert.True(jsonResult.IsSuccess);
        }
        
        [Fact]
        public async Task  IsGetOrdersApiReturnsExpectedResult()
        {
            var orderPostDataModel = Randomizer.CreateRandomOrderModel();

            var json = JsonSerializer.Serialize(orderPostDataModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _orderApiClient.PostAsync("api/orders", content);
            var jsonResult =
                await response.Content.ReadFromJsonAsync<BaseResponseResult>();

            //Assert
            Assert.NotNull(jsonResult);
            Assert.True(jsonResult.IsSuccess);
        }
    }
}
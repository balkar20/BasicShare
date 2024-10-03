using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Core.Transfer;
using EventBus.Constants;
using EventBus.Events.Interfaces;
using EventBus.Messages.Interfaces;
using MassTransit;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using Mod.Order.Models;
using Mod.Product.Models;
using SagaOrchestrationStateMachine.StateInstances;
using SagaOrchestrationStateMachine.StateMachines;

namespace EventIntegrationTest.Tests
{
    public class OrderApiTest
    {
        private readonly TestOrderApiApplication _testOrderApiApplication;
        private readonly TestProductApiApplication _productApiApplication;
        private readonly MockServices _mockServices;
        public readonly HttpClient _orderApiClient;
        public readonly HttpClient _productApiClient;
        public readonly HttpClient _massTransitApiClient;

        public OrderApiTest()
        {
            _mockServices = new MockServices();
            _testOrderApiApplication = new TestOrderApiApplication(_mockServices);
            _productApiApplication = new TestProductApiApplication(_mockServices);

            _orderApiClient = _testOrderApiApplication.CreateClient();
            _productApiClient = _productApiApplication.CreateClient();
        }

        [Fact]
        public async Task ProductAppStart()
        {
            var orderPostDataModel = Randomizer.CreateRandomProductModel();
            var json = JsonSerializer.Serialize(orderPostDataModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _productApiClient.PostAsync("api/products", content);
            var jsonResult =
                await response.Content.ReadFromJsonAsync<BaseResponseResult>().ConfigureAwait(false);
            Assert.True(jsonResult?.IsSuccess);

            
        }

        [Fact]
        public async Task IsPostOrderPublishCorrectEventStateMachine()
        {
            var productsResult = await CallGetProducts();

            await using var provider =
                BuildRabbitMqProvider("guest", "guest", QueuesConsts.CreateOrderMessageQueueName);
            var harness = provider.GetRequiredService<ITestHarness>();
            await harness.Start();
            
            var orderPostDataModel = Randomizer.CreateRandomOrderModel();
            var json = JsonSerializer.Serialize(orderPostDataModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var orderResponse = await _orderApiClient.PostAsync("api/orders", content);
            var orderResponseResult =
                await orderResponse.Content.ReadFromJsonAsync<ResponseResultWithData<OrderIdModel>>();


            // var sagaHarness = harness.GetSagaStateMachineHarness<OrderStateMachine, OrderStateInstance>();

            var consumedCreatedOrderMessage = await harness.Consumed.Any<ICreateOrderMessage>();
            var doesPriceCorresponding =
                await harness.Consumed.Any<ICreateOrderMessage>(o =>
                    ((ICreateOrderMessage)o.MessageObject).TotalPrice ==
                    orderPostDataModel.OrderPaymentInfoModel.Price);
            var publishedOrderCreatedEvent = await harness.Published.Any<EventBus.Events.OrderCreatedEvent>();
            var publishedStockReservedEvent = await harness.Consumed.Any<IStockReservedEvent>();

            var productsNewResult = await CallGetProducts();

            // Assert.Equal(productsJsonResult?.Data.Description, );


            Assert.True(orderResponseResult?.IsSuccess);
            Assert.Equal(0, orderResponseResult?.Data?.Version);
            Assert.True(publishedStockReservedEvent);
            Assert.True(publishedOrderCreatedEvent);
            Assert.True(consumedCreatedOrderMessage);
            Assert.True(doesPriceCorresponding);

            Assert.True(productsResult != null && productsResult.IsSuccess);
            Assert.True(productsNewResult != null && productsNewResult.IsSuccess);
            Assert.Equal(productsResult.Data.Count + 1, productsNewResult.Data.Count);
        }

        [Fact]
        public async Task IsGetOrdersApiReturnsExpectedResult()
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

        private async Task<ResponseResultWithData<List<ProductModel>>?> CallGetProducts()
        {
            var productsResponse = await _productApiClient.GetAsync("api/products");
            return await productsResponse.Content.ReadFromJsonAsync<ResponseResultWithData<List<ProductModel>>>();
        }

        private ServiceProvider BuildRabbitMqProvider(string username, string password,
            string createOrderMessageQueueName)
        {
            return new ServiceCollection()
                .AddMassTransitTestHarness(cfg =>
                {
                    cfg.AddSagaStateMachine<OrderStateMachine, OrderStateInstance>();
                    cfg.SetTestTimeouts(testInactivityTimeout: TimeSpan.FromSeconds(8));
                    cfg.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host("localhost", host =>
                        {
                            host.Username(username);
                            host.Password(password);
                        });
                        cfg.ReceiveEndpoint(createOrderMessageQueueName,
                            e => { e.ConfigureSaga<OrderStateInstance>(context); });
                    });
                })
                .BuildServiceProvider(true);
        }
    }
}
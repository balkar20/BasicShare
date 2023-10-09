using Infrastructure.Interfaces;
using Infrastructure.Services;
using Mod.Order.EventData.Aggregates;
using Mod.Order.Models;
using Mod.Order.Models.Enums;
using MongoDataServices;
using MongoObjects;
using Moq;

namespace Mod.Order.Services.Test;

public class UnitTest1
{
    private Mock<IMessageBusService> _publisherMock;
    private Mock<IDataCollectionService<EventDocument>> _eventStorageMock;
    private AggregateStorage _aggregateStorage;
    
    
    [Fact]
    public async Task SaveEvents_WithValidData_ShouldSaveEventsAndPublishMessages()
    {
        // Arrange
        Guid aggregateId = Guid.NewGuid();
        int expectedVersion = 0;
        var events = new List<EventDocument> { new EventDocument() };

        // Act
        await _aggregateStorage.SaveEvents(aggregateId, events, expectedVersion);

        // Assert
        _eventStorageMock.Verify(mock => mock.CreateAsync(It.IsAny<EventDocument>()), Times.Once);
        _publisherMock.Verify(mock => mock.PublishMessage(It.IsAny<EventDocument>()), Times.Once);
    }
    
    [Fact]
    public async Task SaveEvents_WithValidData_ShouldSaveEventsAndPublishMeges()
    {
        
        OrderModel order = new OrderModel
        {
            Id = 0,
            Description = "null",
            OrderType = OrderType.Product,
            OrderStatus = OrderStatus.Created,
            OrderPayloadId = 0,
            PaymentInfo = new PaymentInfo(),
            Notification = new OrderNotification(),
            CustomerInfo = new CustomerInfo()
        };
        // Arrange
        var oag = new OrderAggregate(Guid.NewGuid(), order);
        
        
        Assert.Equal("null", oag.Description);
        
    }
}
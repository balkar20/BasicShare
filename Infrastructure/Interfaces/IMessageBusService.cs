namespace Infrastructure.Interfaces;

public interface IMessageBusService {
    public Task PublishMessage<TModel>(TModel message);
}
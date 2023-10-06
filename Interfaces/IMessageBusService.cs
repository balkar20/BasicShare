namespace Infrastructure.Interfaces;

public interface IMessageBusService {
    public void PublishMessage<TModel>(TModel message);
}
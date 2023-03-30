namespace Infrastructure.Interfaces;

public interface IRabbitMqProducer {
    public void SendMessage<TModel>(TModel message);
}
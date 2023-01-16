namespace Infrastructure.Interfaces;

public interface IRabitMQProducer {
    public void SendMessage<TModel>(TModel message);
}
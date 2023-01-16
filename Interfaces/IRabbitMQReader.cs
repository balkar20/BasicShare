namespace Infrastructure.Interfaces;

public interface IRabbitMQReader
{
    void ListenEventsFromQue<TModel>(Action<TModel> handler);
}
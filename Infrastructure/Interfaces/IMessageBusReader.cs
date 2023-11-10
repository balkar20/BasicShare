namespace Infrastructure.Interfaces;

public interface IMessageBusReader
{
    void ListenEventsFromQue<TModel>(Action<TModel> handler);
}
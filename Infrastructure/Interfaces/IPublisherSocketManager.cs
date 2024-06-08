using NetMQ.Sockets;

namespace Infrastructure.Interfaces
{
    public interface IPublisherSocketManager
    {
        public PublisherSocket PublisherSocket { get; }
    }
}
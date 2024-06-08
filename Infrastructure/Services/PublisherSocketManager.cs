using Infrastructure.Interfaces;
using NetMQ.Sockets;

namespace Infrastructure.Services
{
    public class PublisherSocketManager: IPublisherSocketManager
    {
        public PublisherSocket PublisherSocket { get; }
        
        public PublisherSocketManager()
        {
            PublisherSocket = new PublisherSocket(">tcp://127.0.0.1:5678");
            PublisherSocket.Options.SendHighWatermark = 1000;
            Console.WriteLine("Publisher socket connecting...");
        }
        
        public void Dispose()
        { 
        }
    }
}
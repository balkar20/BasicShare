using Infrastructure.Interfaces;

namespace Infrastructure.Services
{
    public class OpenSleightMessageBusService: IMessageBusService
    {
        public async Task PublishMessage<TModel>(TModel message)
        {
            
        }
    }
}
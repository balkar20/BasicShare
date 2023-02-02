using StackExchange.Redis;

namespace RedisCache;

public class RedisContext
{
    private static Lazy<ConnectionMultiplexer> lazyConnection;

    public  ConnectionMultiplexer Connection
    {
        get
        {
            return lazyConnection.Value;
        }
    }

    public RedisContext(string connectionUrl)
    {
        RedisContext.lazyConnection = new Lazy<ConnectionMultiplexer>(() => 
        {
            return ConnectionMultiplexer.Connect(connectionUrl);
        });
    }
}
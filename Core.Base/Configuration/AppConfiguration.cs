namespace Core.Base.Configuration;

public class AppConfiguration : BaseConfiguration
{

    public AppConfiguration(Func<string, string?> getConfigFunc) : base(getConfigFunc)
    {
    }
    public bool UseCache => GetConfigFuncBool("USE_CACHE");

    public string LokiUrl => GetConfigFuncString("LOKI_CONNECTION");

    public string LokiUserName => GetConfigFuncString("LOKI_USER_NAME");

    public string LokiPassword => GetConfigFuncString("LOKI_PASSWORD");

    public string RedisUrl => GetConfigFuncString("REDIS_CONNECTION");

    public bool DockerRunning => GetConfigFuncBool("CONTAINER_RUN");

    public string DbConnection => GetConfigFuncString("DB_CONNECTION");

}
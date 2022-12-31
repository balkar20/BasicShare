using Core.Base.Evironment;

namespace Core.Base.Configuration;

public class AppConfiguration : BaseConfiguration
{

    public AppConfiguration(Func<string, string?> getConfigFunc) : base(getConfigFunc)
    {
    }

    // public AppConfiguration(Func<string, string> getConfigFunc): base(getConfigFunc)

    // public bool UseCache { get => GetConfigFuncString("kjkj") == "Y"; }
    //
    // public string LokiUrl { get; set; }
    //
    // public string LokiUserName { get; set; }
    //
    // public string LokiPassword { get; set; }
    //
    // public string RedisUrl { get; set; }
    //
    // public bool DockerRunning { get; set; }
    //
    // public string DbConnection { get; set; }
    //
    // public void LoadEnvironment(Func<string, string>  getConfigFunc)
    // {
    //     LokiUserName =  getConfigFunc("LOKI_USER_NAME");
    //     LokiPassword =  getConfigFunc("LOKI_PASSWORD");
    //     LokiUrl =  getConfigFunc("LOKI_CONNECTION");
    //     RedisUrl =  getConfigFunc("REDIS_CONNECTION");
    //     DockerRunning = getConfigFunc("CONTAINER_RUN") == "Y";
    //     DbConnection =  getConfigFunc("DB_CONNECTION");
    //     UseCache = getConfigFunc("USE_CACHE") == "Y";
    // }
    public bool UseCache => GetConfigFuncBool("USE_CACHE");

    public string LokiUrl => GetConfigFuncString("LOKI_CONNECTION");

    public string LokiUserName => GetConfigFuncString("LOKI_USER_NAME");

    public string LokiPassword => GetConfigFuncString("LOKI_PASSWORD");

    public string RedisUrl => GetConfigFuncString("REDIS_CONNECTION");

    public bool DockerRunning => GetConfigFuncBool("CONTAINER_RUN");

    public string DbConnection => GetConfigFuncString("DB_CONNECTION");

    // public void LoadEnvironment(Func<string, string>  getConfigFunc)
    // {
    //     LokiUserName =  getConfigFunc("LOKI_USER_NAME");
    //     LokiPassword =  getConfigFunc("LOKI_PASSWORD");
    //     LokiUrl =  getConfigFunc("LOKI_CONNECTION");
    //     RedisUrl =  getConfigFunc("REDIS_CONNECTION");
    //     DockerRunning = getConfigFunc("CONTAINER_RUN") == "Y";
    //     DbConnection =  getConfigFunc("DB_CONNECTION");
    //     UseCache = getConfigFunc("USE_CACHE") == "Y";
    // }
    
}
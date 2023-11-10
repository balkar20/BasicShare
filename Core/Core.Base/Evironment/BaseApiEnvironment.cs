namespace Core.Base.Evironment;

public static class BaseApiEnvironment
{
    public static string LokiUrl { get; set; }
    
    public static string LokiUserName { get; set; }
    
    public static string LokiPassword { get; set; }
    
    public static string RedisUrl { get; set; }
    
    public static bool DockerRunning { get; set; }
    
    public static string DbUrl { get; set; }

    public static void LoadEnvironment()
    {
        // LokiUrl = configuration.FirstOrDefault(f => f.Key == "LOKI_CONNECTION").Value;
        // RedisUrl = configuration.FirstOrDefault(f => f.Key == "REDIS_CONNECTION").Value;
        // DockerRunning = Convert.ToBoolean(configuration.FirstOrDefault(f => f.Key == "CONTAINER_RUN").Value);
        // DbUrl = configuration.FirstOrDefault(f => f.Key == "DB_CONNECTION").Value;
        // LokiUserName = configuration.FirstOrDefault(f => f.Key == "LOKI_USER_NAME").Value;
        // LokiPassword = configuration.FirstOrDefault(f => f.Key == "LOKI_PASSWORD").Value;
        // RedisUrl = configuration.FirstOrDefault("").Value;
        // DockerRunning = Convert.ToBoolean(Environment.GetEnvironmentVariable("CONTAINER_RUN"));
        // DbUrl = Environment.GetEnvironmentVariable("DB_CONNECTION");
        LokiUserName = Environment.GetEnvironmentVariable("LOKI_USER_NAME");
        LokiPassword = Environment.GetEnvironmentVariable("LOKI_PASSWORD");
        LokiUrl = Environment.GetEnvironmentVariable("LOKI_CONNECTION", EnvironmentVariableTarget.Machine);
        RedisUrl = Environment.GetEnvironmentVariable("REDIS_CONNECTION", EnvironmentVariableTarget.Machine);
        DockerRunning = Convert.ToBoolean(Environment.GetEnvironmentVariable("CONTAINER_RUN", EnvironmentVariableTarget.Machine));
        DbUrl = Environment.GetEnvironmentVariable("DB_CONNECTION", EnvironmentVariableTarget.Machine);
    }
}
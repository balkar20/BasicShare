using Data.IdentityDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Storage.AppStorage;

public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var builder = new DbContextOptionsBuilder<ApplicationContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        //builder.UseNpgsql(connectionString);
        builder.UseMySql(
            "server=127.0.0.1;uid=b124733_dbuser;pwd=<?A=sv@g~yq2%pBg;database=b124733_db;",
                new MySqlServerVersion(new Version(8, 0, 11)));
        return new ApplicationContext(builder.Options);
    }
}
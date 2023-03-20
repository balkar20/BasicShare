using Data.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mod.Product.Base.Queries;
using Mod.Product.Base.Repositories;
using Mod.Product.Interfaces;
using Mod.Product.Root.Configuration;
using Mod.Product.Services;

namespace Mod.Product.Root.ExtenalServices;

public class ModProductExternalServicesConfigurator
{
    private readonly IServiceCollection _services;
    private readonly ProductEnvironmentContext _productEnvironmentContext;

    public ModProductExternalServicesConfigurator(IServiceCollection services, ProductEnvironmentContext productEnvironmentContext)
    {
        _services = services;
        _productEnvironmentContext = productEnvironmentContext;
    }

    public void Configure()
    {
        _services.AddOptions();
        _services.AddAutoMapper(typeof(GetAllProductsQuery).Assembly); 
        _services.AddMediatR(typeof(GetAllProductsQuery).Assembly);

        ConfigureDataBase();
    }

    private void ConfigureDataBase()
    {
        _services.AddDbContext<ApiDbContext>(options =>
            options.UseNpgsql(
                _productEnvironmentContext.AppConfiguration.DbConnection
            ));
    }
}
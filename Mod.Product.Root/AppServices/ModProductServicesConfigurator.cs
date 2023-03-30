using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Mod.Product.Base.Repositories;
using Mod.Product.Interfaces;
using Mod.Product.Services;
using Mod.Product.Services.Listeners;

namespace Mod.Product.Root.AppServices;

public class ModProductServicesConfigurator
{
    private readonly IServiceCollection _services;
    
    public ModProductServicesConfigurator(IServiceCollection services)
    {
        _services = services;
    }

    public void Configure()
    {
        _services.AddScoped<IProductRepository, ProductRepository>();
        _services.AddScoped<IProductService, ProductService>();
    }
}
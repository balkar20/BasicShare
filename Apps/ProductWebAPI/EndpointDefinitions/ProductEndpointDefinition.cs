using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mod.Product.Base.Commands;
using Mod.Product.Base.Queries;
using Mod.Product.Base.Repositories;
using Mod.Product.Interfaces;
using Mod.Product.Services;
using Mod.Product.Models;


namespace Apps.EndpointDefinitions.ProductWebAPI;

public class ProductEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => "Startup Tool Template");
        app.MapGet("api/products", ([FromServices] IMediator _mediator) => _mediator.Send(new GetAllProductsQuery()));
        app.MapGet("api/testLogger", ([FromServices] IMediator _mediator) => _mediator.Send(new GetTempQuery()));
        app.MapPost("api/products",
            ([FromServices] IMediator _mediator, [FromBody] ProductModel product) =>
                _mediator.Send(new CreateProductCommand(product)));
        app.MapPut("api/products",
            ([FromServices] IMediator _mediator, [FromBody] ProductModel product) =>
                _mediator.Send(new UpdateProductCommand(product)));
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductSqlRepository>();
        services.AddScoped<IProductService, ProductService>();
    }
}
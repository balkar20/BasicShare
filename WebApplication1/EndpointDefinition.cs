using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mod.Product.Base.Queries;
using Mod.Product.Base.Repositories;


namespace WebApplication1;

public class EndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => "Hello World2!");
        app.MapGet("/products", ([FromServices]IMediator _mediator) => _mediator.Send(new GetAllProductsQuery()));
        app.MapPost("/products", ([FromServices]IMediator _mediator) => _mediator.Send(new GetAllProductsQuery()));
    }
    
    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
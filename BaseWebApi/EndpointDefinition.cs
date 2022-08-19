using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.Extensions.Caching.Distributed;
using Mod.Product.Base.Commands;
using Mod.Product.Base.Models;
using Mod.Product.Base.Queries;
using Mod.Product.Base.Repositories;


namespace Apps.BaseWebApi;

public class EndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => "Hello World2!");
        app.MapGet("api/products", ([FromServices]IMediator _mediator) => _mediator.Send(new GetAllProductsQuery()));
        app.MapGet("api/products", ([FromServices]IMediator _mediator) => _mediator.Send(new GetAllProductsQuery()));
        app.MapPost("api/products", ([FromServices]IMediator _mediator, [FromBody] ProductModel product) => _mediator.Send(new CreateProductCommand(product)));
        app.MapPut("api/products", ([FromServices]IMediator _mediator, [FromBody] ProductModel product) => _mediator.Send(new UpdateProductCommand(product)));
    }
    
    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
    }

    // private void SetEndPoint<TModel>(string url, WebApplication app, TModel model, Func<RouteHandlerBuilder, IEndpointRouteBuilder, RouteTemplate, Delegate> map)
    // {
    //      // IMediator _mediator;
    //      // IDistributedCache _cache;
    //      
    //      app.MapGet(url, ([FromServices]IMediator _mediator, [FromServices]IDistributedCache _distributedCace) => _mediator.Send(new GetAllProductsQuery()));
    //      
    // }
}
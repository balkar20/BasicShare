using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mod.Product.Base.Commands;
using Mod.Product.Base.Queries;
using Mod.Product.Base.Repositories;
using Mod.Product.Interfaces;
using ModProduct.Models;


namespace Apps.BaseWebApi;

public class EndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => "Startup Tool Template");
        app.MapGet("api/products", ([FromServices]IMediator _mediator) => _mediator.Send(new GetAllProductsQuery()));
        app.MapPost("api/products", ([FromServices]IMediator _mediator, [FromBody] ProductModel product) => _mediator.Send(new CreateProductCommand(product)));
        app.MapPut("api/products", ([FromServices]IMediator _mediator, [FromBody] ProductModel product) => _mediator.Send(new UpdateProductCommand(product)));
    }
    
    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
    }

    //private void SetRequestEndPoint<TModel, TRequest>(string url, WebApplication app, TModel model, IRequest<TRequest> request, Func<RouteHandlerBuilder, IEndpointRouteBuilder, RouteTemplate, Action<IMediator>> map)
    //    where TModel : class, new()
    //{
    //    // IMediator _mediator;
    //    // IDistributedCache _cache;

    //    map(url, ([FromServices] IMediator _mediator, [FromServices] IDistributedCache _distributedCace) => _mediator.Send(request));

    //}
}
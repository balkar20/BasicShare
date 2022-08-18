using Db;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModProduct.Handlers;
using ModProduct.Queries;
using ModProduct.Repositories;
using Sevices;

namespace WebApplication1;

public class EndpointDefinition : IEndpointDefinition
{
    // private readonly IMediator _mediator;
    //
    // public EndpointDefinition(IMediator mediator)
    // {
    //     _mediator = mediator;
    // }
    
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => "Hello World2!");
        app.MapGet("/products", ([FromServices]IMediator _mediator) => _mediator.Send(new GetAllProductsQuery()));
        // app.MapGet("/blogs", ([FromServices]   blogService) => blogService.GetBlogs());
    }
    
    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
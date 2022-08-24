﻿namespace Apps.BaseWebApi;

public class EndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => "Hello World2!");
        app.MapGet("/products", ([FromServices]IMediator _mediator) => _mediator.Send(new GetAllProductsQuery()));
        app.MapPost("/products", ([FromServices]IMediator _mediator, [FromBody] ProductModel product) => _mediator.Send(new CreateProductCommand(product)));
    }
    
    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
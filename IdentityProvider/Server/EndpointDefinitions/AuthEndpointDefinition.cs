using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mod.Auth.Base.Commands;
using Mod.Auth.Base.Queries;
using Mod.Auth.Base.Repositories;
using Mod.Auth.Base.ViewModels;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;
using Mod.Order.Base.Commands;
using Mod.Order.Models;


namespace Apps.Blazor.Identity.IdentityProvider.Server.EndpointDefinitions;

public class AuthEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        //app.MapGet("/", () => "Startup Tool Template");
        app.MapGet("api/poopers", ([FromServices] IMediator _mediator) => _mediator.Send(new GetAllUsersQuery()));
        app.MapPut("api/pooper", ([FromServices] IMediator _mediator, [FromBody] PooperModel pooperModel) => _mediator.Send(new SavePooperCommand(pooperModel)));
        app.MapPost("api/order", ([FromServices] IMediator _mediator, [FromBody] OrderModel orderModel) => _mediator.Send(new CreateOrderCommand(orderModel)));
        app.MapPost("api/login",
            ([FromServices] IMediator _mediator, [FromBody] LoginViewModel product) =>
                _mediator.Send(new LoginCommand(product)));
        app.MapPost("api/register",
            ([FromServices] IMediator _mediator, [FromBody] RegisterViewModel product) =>
                _mediator.Send(new RegisterCommand(product)));
        //app.MapPut("api/products",
        //    ([FromServices] IMediator _mediator, [FromBody] AuthModel product) =>
        //        _mediator.Send(new UpdateAuthCommand(product)));
        
        AddSomeRoutes(app);
    }

    private void AddSomeRoutes(WebApplication app)
    {
        app.MapGet("api/someroute", () => "This is someRoute!");
    }

    public void DefineServices(IServiceCollection services)
    {
        //services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IAuthService, AuthService>();
        //services.AddScoped<AuthStateProvider>();
        //services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<AuthStateProvider>());
    }
}
using Core.Transfer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mod.Auth.Base.Commands;
using Mod.Auth.Base.Queries;
using Mod.Auth.Base.ViewModels;
using Mod.Auth.Models;

namespace Apps.Blazor.Identity.IdentityProvider.Server.EndpointDefinitions;

public class AuthEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("api/users", ([FromServices] IMediator _mediator, DataListPagingModel pagingModel) => _mediator.Send(new GetAllUsersQuery(pagingModel)));
        app.MapPut("api/users", ([FromServices] IMediator _mediator, [FromBody] UserModel pooperModel) => _mediator.Send(new SaveUserCommand(pooperModel)));
        // app.MapPost("api/order", ([FromServices] IMediator _mediator, [FromBody] OrderModel orderModel) => _mediator.Send(new CreateOrderCommand(orderModel)));
        app.MapPost("api/login",
            ([FromServices] IMediator _mediator, [FromBody] LoginViewModel product) =>
                _mediator.Send(new LoginCommand(product)));
        app.MapPost("api/register",
            ([FromServices] IMediator _mediator, [FromBody] RegisterViewModel product) =>
                _mediator.Send(new RegisterCommand(product)));

        AddSomeRoutes(app);
    }

    private void AddSomeRoutes(WebApplication app)
    {
        app.MapGet("api/someroute", () => "This is someRoute!");
    }

    public void DefineServices(IServiceCollection services)
    {
        //services.AddScoped<IAuthRepository, AuthRepository>();
        // services.AddScoped<IAuthService, AuthService>();
        //services.AddScoped<AuthStateProvider>();
        //services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<AuthStateProvider>());
    }
}
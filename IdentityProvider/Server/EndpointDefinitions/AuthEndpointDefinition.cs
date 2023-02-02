using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mod.Auth.Base.Commands;
using Mod.Auth.Base.Queries;
using Mod.Auth.Base.Repositories;
using Mod.Auth.Base.ViewModels;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;


namespace Apps.Blazor.Identity.IdentityProvider.Server.EndpointDefinitions;

public class AuthEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        //app.MapGet("/", () => "Startup Tool Template");
        app.MapGet("api/poopers", ([FromServices] IMediator _mediator) => _mediator.Send(new GetAllAuthsQuery()));
        app.MapPost("api/login",
            ([FromServices] IMediator _mediator, [FromBody] LoginViewModel product) =>
                _mediator.Send(new LoginCommand(product)));
        app.MapPost("api/register",
            ([FromServices] IMediator _mediator, [FromBody] RegisterViewModel product) =>
                _mediator.Send(new RegisterCommand(product)));
        //app.MapPut("api/products",
        //    ([FromServices] IMediator _mediator, [FromBody] AuthModel product) =>
        //        _mediator.Send(new UpdateAuthCommand(product)));
    }

    public void DefineServices(IServiceCollection services)
    {
        //services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IAuthService, AuthService>();
        //services.AddScoped<AuthStateProvider>();
        //services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<AuthStateProvider>());
    }
}
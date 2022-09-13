using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mod.Auth.Base.Commands;
using Mod.Auth.Base.Queries;
using Mod.Auth.Base.Repositories;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;
using Mod.Auth.Services;


namespace Apps.EndpointDefinitions.BaseWebApi;

public class AuthEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => "Startup Tool Template");
        app.MapGet("api/products", ([FromServices] IMediator _mediator) => _mediator.Send(new GetAllAuthsQuery()));
        app.MapPost("api/products",
            ([FromServices] IMediator _mediator, [FromBody] UserModel product) =>
                _mediator.Send(new CreateAuthCommand(product)));
        app.MapPut("api/products",
            ([FromServices] IMediator _mediator, [FromBody] UserModel product) =>
                _mediator.Send(new UpdateAuthCommand(product)));
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IAuthService, AuthService>();
    }
}
using System.Net;
using System.Text.Json;
using Core.Base.Exceptions;

namespace Apps.Blazor.Identity.IdentityProvider.Server.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            // var str = context.Response.Body;
            response.ContentType = "application/json";

            response.StatusCode = error switch
            {
                AppException e =>
                    // custom application error
                    (int)HttpStatusCode.BadRequest,
                KeyNotFoundException e =>
                    // not found error
                    (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(result);
        }
    }
}
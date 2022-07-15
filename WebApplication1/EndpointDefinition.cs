using Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sevices;

namespace WebApplication1;

public class EndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => "Hello World2!");
        app.MapGet("/blogs", ([FromServices]  IBlogService blogService) => blogService.GetBlogs());
    }
    
    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IBlogService, BlogService>();

    }
}
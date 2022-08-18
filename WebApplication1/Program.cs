using Db;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mod.Product.Base.Queries;
using WebApplication1;
using WebApplication1.Extensions;

var builder = WebApplication.CreateBuilder(args);



// var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
var connectionString = builder.Configuration.GetConnectionString("ProductDb");
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(
        connectionString
    ));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 
builder.Services.AddMediatR(typeof(GetAllProductsQuery).Assembly);
builder.Services.AddEndpointDefinitions(typeof(Dodo));

var app = builder.Build();
//var dbContext = app.Services.GetService<ApiDbContext>();
//dbContext?.Database.EnsureCreated();
//dbContext?.Database.Migrate();

app.UseEndpointDefinitions();
//using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
//{
//    var context = serviceScope.ServiceProvider.GetService <ApiDbContext>();
//    context.Database.Migrate();
//}


// app.MapGet("/blogs", ([FromServicesAttribute]  IBlogService blogService) => blogService.GetBlogs());

app.Run();
using Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sevices;
using WebApplication1;
using WebApplication1.Extensions;

var builder = WebApplication.CreateBuilder(args);



// var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
var connectionString = builder.Configuration.GetConnectionString("ProductDb");
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(
        connectionString
    ));
builder.Services.AddEndpointDefinitions(typeof(Dodo));
//builder.Services.AddSingleton<IBlogService, BlogService>();

var app = builder.Build();

app.UseEndpointDefinitions();

// var dbContext = app.Services.GetService<ApiDbContext>();
// dbContext?.Database.EnsureCreated();
// dbContext?.Database.Migrate();

// app.MapGet("/blogs", ([FromServicesAttribute]  IBlogService blogService) => blogService.GetBlogs());

app.Run();
using Db;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mod.Product.Base.Queries;
using Serilog;
using Apps.BaseWebApi;
using Apps.BaseWebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ProductDb");

builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(
        connectionString
    ));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("RedisCacheUrl");
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 
builder.Services.AddMediatR(typeof(GetAllProductsQuery).Assembly);
builder.Services.AddEndpointDefinitions(typeof(EndpointDefinition));
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341"));



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseEndpointDefinitions();
app.Run();
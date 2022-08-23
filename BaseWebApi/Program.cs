using Db;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mod.Product.Base.Queries;
using Serilog;
using Apps.BaseWebApi;
using Apps.BaseWebApi.Extensions;
using Core.Base.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;


IConfiguration Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ProductDb");
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(
        connectionString
    ));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ProductApiConfiguration>(
    builder.Configuration.GetSection(ProductApiConfiguration.AuthConfiguration));

ProductApiConfiguration productApiConfiguration = builder.Configuration.GetSection(ProductApiConfiguration.AuthConfiguration).Get<ProductApiConfiguration>();
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
//     {
//         options.Authority = productApiConfiguration.IdentityServerBaseUrl;
//         options.RequireHttpsMetadata = productApiConfiguration.RequireHttpsMetadata;
//         options.Audience = productApiConfiguration.OidcApiName;
//     });


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
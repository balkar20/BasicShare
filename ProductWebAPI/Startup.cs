using Serilog;
using Apps.ProductWebAPI.Extensions;
using Apps.EndpointDefinitions.ProductWebAPI;
using Core.Base.Configuration;
using Core.Base.ConfigurationInterfaces;
using Data.Db;
using ProductWebApi.Middlewares;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mod.Product.Base.Queries;

namespace ProductWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEndpointDefinitions(typeof(ProductEndpointDefinition));
            
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "LokiGraProductWebAPIPI", Version = "v1" });
            // });

            var appConfiguration = new AppConfiguration(Configuration.GetValue<string>);
            var productConfiguration = new ProductApiConfiguration(Configuration.GetValue<string>);
            services.AddSingleton<AppConfiguration>(x => appConfiguration);
            services.AddSingleton<IProductApiConfiguration>(x => productConfiguration);
            
            services.AddOptions();
            services.AddAutoMapper(typeof(GetAllProductsQuery).Assembly); 
            services.AddMediatR(typeof(GetAllProductsQuery).Assembly);

            services.AddDbContext<ApiDbContext>(options =>
                options.UseNpgsql(
                    appConfiguration.DbConnection
                ));
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",ProductWebAPI "ProductWebApi v1"));
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();
            //to log Requests
            app.UseSerilogRequestLogging();

            // app.UseHttpsRedirection();

            app.UseRouting();
            // app.UseAuthorization();
            ((WebApplication)app).UseEndpointDefinitions();
        }
    }
}

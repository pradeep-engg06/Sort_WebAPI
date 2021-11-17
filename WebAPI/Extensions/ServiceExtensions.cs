using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
 
namespace WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCustomServices(this IServiceCollection services) {
            services.AddScoped<API.Service.WithoutInbuildFunctionSortService>();
            services.AddScoped<API.Service.InbuiltFunctionSortService>();
          

            
            services.AddScoped<API.Service.ServiceResolver>(servicesprovider => key => {
                switch (key)
                {
                    case "WithoutInbuildFunction":
                        return servicesprovider.GetRequiredService<API.Service.WithoutInbuildFunctionSortService>();
                    case "WithInbuildFunction":
                        return servicesprovider.GetRequiredService<API.Service.InbuiltFunctionSortService>();
                    default:
                        throw new KeyNotFoundException();
                }
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services) {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web API ", Version = "v1" });
            });
        }
    }
}

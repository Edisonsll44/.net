using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Soulsplit.Api.ServiciosDistribuidos.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddRegister(this IServiceCollection service)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var xmlPath = Path.Combine(basePath, "Soulsplit.Api.ServiciosDistribuidos.xml");
            service.AddSwaggerGen(sw =>
            {
                //sw.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Soulsplit API V1", Version = "V1" });
                sw.IncludeXmlComments(xmlPath);
                });
            return service;
        }

        public static IApplicationBuilder AddRegister(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(sw=> sw.SwaggerEndpoint("/swagger/v1/swagger.json", "Soulsplit API V1"));
            return app;
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace Project.Hub.Api.Config
{
    internal static class Swagger
    {
        /// <summary>
        /// Add Swagger configuration with all required generation options and configured docs.
        /// </summary>
        public static IServiceCollection AddPreConfiguredSwagger(this IServiceCollection services)
        {
            return services
                .AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Project Hub", Version = "v1" });

                    var docs = new[] {
                        "Project.Hub.Api.xml",
                        "Project.Hub.Data.xml",
                        "Project.Hub.Domain.xml",
                    };
                    foreach (var doc in docs)
                    {
                        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, doc));
                    }
                })
                .AddSwaggerGenNewtonsoftSupport();
        }

        /// <summary>
        /// Use configured Swagger with UI.
        /// </summary>
        public static IApplicationBuilder UsePreConfiguredSwaggerWithUI(this IApplicationBuilder app)
        {
            return app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Project Hub API v1");
                    options.DisplayRequestDuration();
                    options.EnableFilter();
                });
        }
    }
}

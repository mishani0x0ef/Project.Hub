using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Project.Hub.Api.Config
{
    internal static class Cors
    {
        private const string DevCorsPolicy = "devCorsPolicy";

        /// <summary>
        /// Add CORS policy with allowed origins to communication with the API.
        /// <para>(include configurations for development environment as well)</para>
        /// </summary>
        public static IServiceCollection AddPreConfiguredCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    DevCorsPolicy,
                    builder =>
                    {
                        var allowedOrigins = new[]
                        {
                            "http://localhost:4200",
                        };
                        builder
                            .WithOrigins(allowedOrigins);
                    });
            });

            return services;
        }

        /// <summary>
        /// Enable CORS policies to configure communication between clients and API.
        /// </summary>
        public static IApplicationBuilder UsePreConfiguredCors(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(DevCorsPolicy);
            }

            return app;
        }
    }
}

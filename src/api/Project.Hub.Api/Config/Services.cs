using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Project.Hub.Api.Config
{
    internal static class Services
    {
        /// <summary>
        /// Configure dependency injection of application services.
        /// </summary>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            AddCommon(services);
            return services;
        }

        private static void AddCommon(IServiceCollection services)
        {
            services
                .AddSingleton(Log.Logger)
                ;
        }
    }
}

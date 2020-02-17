using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project.Hub.Data.Contexts;
using Serilog;

namespace Project.Hub.Api.Config
{
    internal static class EntityFramework
    {
        /// <summary>
        /// Create database if not exists and perform all migrations.
        /// </summary>
        public static IHost InitDatabase(this IHost host)
        {
            using(var scope = host.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetService<HubContext>())
            {
                context.Database.EnsureCreated();
                context.Database.Migrate();
            }

            return host;
        }

        /// <summary>
        /// Create pre-configured database context.
        /// </summary>
        public static IServiceCollection AddPreConfiguredDbContexts(this IServiceCollection services, IConfiguration config)
        {
            return services.AddDbContext<HubContext>(
                options =>
                {
                    var loggerFactory = LoggerFactory.Create(
                        builder => builder
                            .AddFilter(IsCommandLog)
                            .AddSerilog()
                    );

                    options.UseLoggerFactory(loggerFactory);
                    options.UseSqlite(config.GetConnectionString("ProjectHubConnection"));
                });
        }

        private static bool IsCommandLog(string category, LogLevel level) =>
            category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information;
    }
}

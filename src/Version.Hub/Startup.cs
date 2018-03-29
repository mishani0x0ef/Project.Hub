using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Version.Hub.Filters;
using Version.Hub.Config;
using Version.Hub.Config.Providers;
using Version.Hub.Settings;

namespace Version.Hub
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDependencyInjection(services);
            services.AddMvc(config => 
            {
                config.Filters.Add<NotFoundErrorFillter>();
            });
            services.Configure<AppConfiguration>(Configuration.GetSection("AppConfiguration"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services
                .AddMemoryCache()
                .AddSingleton<IConfigPathResolver, ConfigResolver>()
                .AddSingleton<IConfigProvider, JsonConfigProvider>()
                .AddSingleton<IVersionProvider, AssemblyVersionProvider>()
                ;
        }
    }
}

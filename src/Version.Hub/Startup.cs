using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Version.Hub.Filters;
using Version.Hub.Config;
using Version.Hub.Config.Providers;

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
                .AddSingleton<IVersionProvider, StaticVersionProvider>()
                ;
        }
    }
}

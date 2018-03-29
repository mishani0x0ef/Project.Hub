using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Providers;
using Project.Hub.Config.Providers.VersionResolvers;
using Project.Hub.Settings;

namespace Project.Hub
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
            ConfigureDependencyInjection(services);
            services.AddMvc();
            services.Configure<AppConfiguration>(Configuration.GetSection("AppConfiguration"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services
                .AddMemoryCache()
                .AddSingleton<IConfigPathResolver, ConfigResolver>()
                .AddSingleton<ICacheExpirationProvider, ConfigResolver>()
                .AddSingleton<Config.Interfaces.IConfigurationProvider, JsonConfigurationProvider>()
                .AddSingleton<VersionResolverFactory>()
                .AddSingleton<IVersionProvider, JsonConfigVersionProvider>()
                ;
        }
    }
}

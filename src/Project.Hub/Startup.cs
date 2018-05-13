using Common.Cache;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Providers;
using Project.Hub.Config.Providers.VersionResolvers;
using Project.Hub.Models;
using Project.Hub.Services;
using Project.Hub.Settings;
using System;

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
            ConfigureAuth(services);
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

            app
                .UseStaticFiles()
                .UseAuthentication()
                .UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureAuth(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddUserStore<VeryVeryHardcodedUserStore>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(24);
                options.LoginPath = "/Account/Login";
                options.SlidingExpiration = true;
            });
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services
                .AddSingleton<ICache, Cache>()
                .AddSingleton<IComponentProvider, ComponentProvider>()
                .AddSingleton<IOptionsProvider, ConfigResolver>()
                .AddSingleton<ICacheExpirationProvider, ConfigResolver>()
                .AddSingleton<Config.Interfaces.IConfigurationProvider, JsonConfigurationProvider>()
                .AddSingleton<VersionResolverFactory>()
                .AddSingleton<IVersionProvider, JsonConfigVersionProvider>()
                .AddSingleton<IRawConfigProvider, RawConfigProvider>()
                ;
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Project.Hub.Api.Config;
using Serilog;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Project.Hub.Api
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
            services
                .AddPreConfiguredCors()
                .AddPreConfiguredResponseCompression()
                .AddServices();

            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services
                .AddPreConfiguredDbContexts(Configuration)
                .AddPreConfiguredSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage()
                    .UseSerilogRequestLogging();
            }

            app
                .UsePreConfiguredCors(env)
                .UseResponseCompression()
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                })
                .UsePreConfiguredSwaggerWithUI();
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

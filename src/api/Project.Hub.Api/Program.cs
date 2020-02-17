using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Project.Hub.Api.Config;
using Serilog;
using System;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Project.Hub.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = InitLogger();

            try
            {
                logger.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UsePreConfiguredSentry();
                    webBuilder.UseSerilog();
                });

        private static ILogger InitLogger()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("serilog.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            return Log.Logger;
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

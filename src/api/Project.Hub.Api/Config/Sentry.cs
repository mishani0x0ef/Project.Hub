using Microsoft.AspNetCore.Hosting;
using Project.Hub.Api.Settings;
using Sentry;

namespace Project.Hub.Api.Config
{
    internal static class Sentry
    {
        /// <summary>
        /// Uses Sentry integration with pre-configured confidential data and request pre-processing.
        /// </summary>
        public static IWebHostBuilder UsePreConfiguredSentry(this IWebHostBuilder builder)
        {
            return builder.UseSentry(options =>
            {
                var settings = AppSettings.Instance;

                options.Release = settings.Version.ToString();
                options.BeforeSend = HideConfidentialInfo;
            });
        }

        private static SentryEvent HideConfidentialInfo(SentryEvent @event)
        {
            @event.ServerName = null;
            return @event;
        }
    }
}

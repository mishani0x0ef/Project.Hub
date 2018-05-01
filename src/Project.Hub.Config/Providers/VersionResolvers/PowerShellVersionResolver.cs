using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Project.Hub.Config.Entities.Version;
using System.Management.Automation;
using System.Linq;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    internal class PowerShellVersionResolver : ResolverWithFallback, IVersionResolver
    {
        private const string RunPowershellCmd = "powershell -ExecutionPolicy ByPass -File ";

        public PowerShellVersionResolver(IVersionResolver fallback, ILogger<IVersionResolver> logger) : base(fallback, logger)
        {
        }

        protected override async Task<string> GetRealVersion(VersionOptions options)
        {
            // https://github.com/PowerShell/PowerShell/tree/master/docs/host-powershell#net-core-sample-application
            // https://github.com/PowerShell/PowerShell/tree/master/docs/host-powershell/sample-dotnet2.0-powershell-crossplatform
            using (PowerShell ps = PowerShell.Create())
            {
                var command = $"{RunPowershellCmd}{options.Path}";

                var results = ps.AddScript(command).Invoke();
                var version = results.FirstOrDefault();
                return version?.ToString();
            }
        }
    }
}

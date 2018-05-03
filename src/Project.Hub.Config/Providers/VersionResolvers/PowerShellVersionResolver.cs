using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Project.Hub.Config.Entities.Version;
using System.Management.Automation;
using System.Linq;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    internal class PowerShellVersionResolver : ResolverWithFallback, IVersionResolver
    {
        protected string RunPowershellCmd { get; set; }

        public PowerShellVersionResolver(string powershellPath, IVersionResolver fallback, ILogger<IVersionResolver> logger) : base(fallback, logger)
        {
            RunPowershellCmd = $"{powershellPath} -ExecutionPolicy ByPass -File ";
        }

        protected override async Task<string> GetRealVersion(VersionOptions options)
        {
            // https://github.com/PowerShell/PowerShell/tree/master/docs/host-powershell#net-core-sample-application
            // https://github.com/PowerShell/PowerShell/tree/master/docs/host-powershell/sample-dotnet2.0-powershell-crossplatform
            using (PowerShell ps = PowerShell.Create())
            {
                var command = $"{RunPowershellCmd}{options.Path}";

                var results = ps.AddScript(command).Invoke();

                if (ps.HadErrors)
                {
                    var error = string.Join("\n", ps.Streams.Error?.Select(e => e.ToString()));
                    throw new System.Exception(error);
                }
                
                var version = results.LastOrDefault();
                return version?.ToString();
            }
        }
    }
}

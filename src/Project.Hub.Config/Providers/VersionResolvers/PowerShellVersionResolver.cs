using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Project.Hub.Config.Entities.Common.Version;
using System.Management.Automation;
using System.Linq;
using System.Text;

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
                    var console = string.Join("\n", results?.Select(r => r.ToString()));

                    var builder = new StringBuilder("PowerShell error:")
                        .AppendLine(error)
                        .AppendLine("PowerShell console output:")
                        .AppendLine(console);

                    throw new System.Exception(builder.ToString());
                }
                
                var version = results.LastOrDefault();
                return version?.ToString();
            }
        }
    }
}

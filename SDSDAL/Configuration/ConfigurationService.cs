using Microsoft.Extensions.Configuration;
using System.IO;

namespace SDSDAL.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        public IEnvironmentService EnvService { get; }

        public ConfigurationService(IEnvironmentService environmentService)
        {
            EnvService = environmentService;
        }

        public IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{EnvService.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}

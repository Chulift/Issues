using Microsoft.Extensions.Configuration;

namespace SDSDAL.Configuration
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}

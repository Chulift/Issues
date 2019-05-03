using Microsoft.Extensions.DependencyInjection;
using SDSDAL.Configuration;
using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace SDSDAL.Controller
{
    public class BaseController
    {
        public static DateTime SQLDateTimeMinValue = (DateTime)SqlDateTime.MinValue;

        // Configuration Service;
        protected IConfigurationService ConfigService { get; }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Register services with DI system;
            serviceCollection.AddTransient<IEnvironmentService, EnvironmentService>();
            serviceCollection.AddTransient<IConfigurationService, ConfigurationService>();

        }

        public BaseController()
        {
            // Setup dependency injection;
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Get configuration service from di system;
            ConfigService = serviceProvider.GetService<IConfigurationService>();
        }

        public BaseController(IConfigurationService configService)
        {
            ConfigService = configService;
        }

        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConfigService.GetConfiguration()["SDSConnectionstring"]);
        }
    }
}

using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using SDSDAL.Configuration;
using System.Collections.Generic;
using System.Net;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace SDSLambdaService
{
    public class BaseFunction
    {
        // Configuration Service;
        protected IConfigurationService ConfigService { get; }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Register services with DI system;
            serviceCollection.AddTransient<IEnvironmentService, EnvironmentService>();
            serviceCollection.AddTransient<IConfigurationService, ConfigurationService>();
        }

        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public BaseFunction()
        {
            // Setup dependency injection;
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Get configuration service from di system;
            ConfigService = serviceProvider.GetService<IConfigurationService>();
        }

        public BaseFunction(IConfigurationService configService)
        {
            ConfigService = configService;
        }

        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The list of blogs</returns>
        public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "Hello AWS Serverless",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }

        public string FunctionHandler(string input, ILambdaContext context)
        {
            // Get config setting using input as a key
            //return ConfigService.GetConfiguration()[input] ?? "None";
            //return new SDSDAL.Controller.BaseController().GetSqlConnection().ConnectionString;
            return "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SDSDAL.Configuration
{
    public class EnvironmentService : IEnvironmentService
    {
        public EnvironmentService()
        {
            EnvironmentName = Environment.GetEnvironmentVariable(Constants.EnvironmentVariables.AspnetCoreEnvironment) ?? Constants.Environments.Production;
        }

        public string EnvironmentName { get; set; }
    }
}

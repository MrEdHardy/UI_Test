using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.ConfigurationHelpers
{
    public static class ConfigurationHelper
    {
        private static Lazy<IConfiguration> configuration = new Lazy<IConfiguration>(CreateConfiguration);

        public static Dictionary<string, string> GetPathDefinitions(ReadOnlySpan<char> controller)
        {
            return configuration.Value.GetSection($"Paths:{controller.ToString()}").Get<Dictionary<string, string>>();
        }

        private static IConfiguration CreateConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "DataAccess/ConfigFiles"))
                .AddJsonFile("config.json")
                .Build();
        }

    }
}

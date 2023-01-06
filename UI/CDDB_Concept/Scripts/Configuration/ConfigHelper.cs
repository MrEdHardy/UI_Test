using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

internal static class ConfigHelper
{
    private static IConfiguration CreateConfiguration(string json)
    {
        return new ConfigurationBuilder()
            .AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(json)))
            .Build();
    }

    internal static Dictionary<string, string> GetPathDefinitions(string controller, string json)
    {
        return CreateConfiguration(json)
            .GetSection($"Paths:{controller.ToString()}")
            .Get<Dictionary<string, string>>();
    }
}
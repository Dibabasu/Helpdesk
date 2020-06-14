using Microsoft.Extensions.Configuration;
using System.IO;

namespace Helpdesk.WebApi
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddHelpdeskConfiguration(this IConfigurationBuilder builder,
            string environmentName, string[] args = null, string path = "")
        {
            builder.AddJsonFile(Path.Combine(path, "appsettings.json"), false, true);
            builder.AddJsonFile(Path.Combine(path, $"appsettings.{environmentName}.json"), true, true);
            builder.AddJsonFile(Path.Combine(path, $"appsettings.local.json"), true, true);

            builder.AddEnvironmentVariables();
            builder.AddCommandLine(args ?? new string[0]);

            return builder;
        }
    }
}
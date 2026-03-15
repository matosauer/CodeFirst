using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CodeFirst.Domain;

internal static class AppSettings
{
    public static IConfigurationRoot? Configuration
    {
        get {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            return configuration;
        }
    }

    public static string? CodeFirstConnection
    {
        get
        {
            return Configuration?.GetConnectionString("CodeFirstConnection");
        }
    }
}
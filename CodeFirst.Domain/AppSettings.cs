using Microsoft.Extensions.Configuration;

namespace CodeFirst.Domain
{
    internal static class AppSettings
    {
        public static IConfigurationRoot? Configuration
        {
            get
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                return configuration;
            }
        }

        public static string? DefaultConnectionString
        {
            get
            {
                return Configuration?.GetConnectionString("DefaultConnection");
            }
        }
    }
}

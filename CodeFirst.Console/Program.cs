using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace CodeFirst.Console;

internal class Program
{
    static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            //var worker = scope.ServiceProvider.GetRequiredService<Worker>();
            var worker = ActivatorUtilities.CreateInstance<Worker>(scope.ServiceProvider);
            worker.Run();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) {

        return Host.CreateDefaultBuilder(args)
           .ConfigureAppConfiguration((context, configuration) =>
           {
            var environmentName = context.HostingEnvironment.EnvironmentName;
            System.Console.WriteLine($"Environment: {environmentName}");

            configuration.Sources.Clear();
            configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);                
            configuration.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);
            configuration.AddCommandLine(args); 
           })
           .ConfigureServices((context, services) =>
           {
               services.AddScoped<ISampleRepository, SampleRepository>();
               //services.AddScoped<Worker>();               
           });
    }        
}

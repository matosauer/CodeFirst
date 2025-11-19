using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CodeFirst.Domain;

namespace CodeFirst.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
               .ConfigureServices((context, services) =>
               {
                   var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                   services.AddDbContext<BloggingContext>(options =>                       
                           options
                            .UseSqlServer(connectionString)
                           // Lazy Loading
                           //.UseLazyLoadingProxies()
                           );

                   services.AddTransient<Worker>();
               })
               .Build();

            using (var scope = host.Services.CreateScope())
            {
                scope
                    .ServiceProvider
                    .GetRequiredService<Worker>()
                    .RunAsync()
                    .Wait();
            }
        }
    }
}

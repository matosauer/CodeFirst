using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CodeFirst.Console;

public class Worker
{
    private readonly ISampleRepository repository;
    private readonly IConfiguration configuration;
    private readonly ILogger<Worker> logger;

    public Worker(ISampleRepository repository, IConfiguration configuration, ILogger<Worker> logger)
    {
        this.repository = repository;
        this.configuration = configuration;
        this.logger = logger;
    }

    public void Run()
    {        
        System.Console.WriteLine("Hello CodeFirst.Console");

        repository.DoSomething();
    }

}

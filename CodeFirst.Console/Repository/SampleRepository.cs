
using CodeFirst.Console;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class SampleRepository : ISampleRepository
{
    private readonly IConfiguration configuration;
    private readonly ILogger<Worker> logger;

    public void DoSomething()
    {
        logger.LogInformation("Doing something...");
    }

    public SampleRepository(IConfiguration configuration, ILogger<Worker> logger)
    {
        this.configuration = configuration;
        this.logger = logger;
    }
}
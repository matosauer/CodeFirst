
using CodeFirst.Console;
using CodeFirst.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class SampleRepository : ISampleRepository
{
    private readonly IConfiguration configuration;
    private readonly ILogger<Worker> logger;
    private readonly BloggingContext db;

    public void DoSomething()
    {
        logger.LogInformation("Doing something...");

        Test test = new Test(db);
        test.RunAsync().Wait();
    }

    public SampleRepository(IConfiguration configuration, ILogger<Worker> logger,  BloggingContext db)
    {
        this.configuration = configuration;
        this.logger = logger;
        this.db = db;
    }
}
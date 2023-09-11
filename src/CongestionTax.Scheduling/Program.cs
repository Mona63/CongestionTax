using CongestionTax.Scheduling;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<DailyHostedService>();
    })
    .Build();

await host.RunAsync();

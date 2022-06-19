using UserBackgroundService;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(configure =>
    {
        configure.ServiceName = "UserRegistrationService";
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();

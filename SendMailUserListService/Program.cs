
using SendMailUserListService;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(configure =>
    {
        configure.ServiceName = "SendMailUserListService";
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();

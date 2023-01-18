using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Sandbox;

// Create a host and configure it.
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
        services.AddHostedService<InteractionService>()
                .AddSingleton<Random>()
).Build();

// Run the host.
await host.RunAsync();
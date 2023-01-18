using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Sandbox.Runtime;

// Create a host and configure it.
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
        services.AddHostedService<InteractionService>()
).Build();

// Run the host.
await host.RunAsync();
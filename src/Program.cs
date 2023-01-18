using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MediatR;

using Sandbox;
using Microsoft.Extensions.Logging;

// Create a host and configure it.
using IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices(services => services
        .AddLogging(logging => logging.AddDebug().AddConsole())
        .AddMediatR(Assembly.GetExecutingAssembly())
        .AddHostedService<InteractionService>()
        .AddSingleton<ModuleFactory>()
        .AddSingleton<Random>()
).Build();

// Run the host.
await host.RunAsync();
using System.Reflection;

using Bonfire.Hosting;
using MediatR;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Sandbox;

internal sealed class Startup : Ignition
{
    protected override void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(logging => logging.AddDebug().AddConsole())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddHostedService<InteractionService>()
                .AddSingleton<ModuleFactory>()
                .AddSingleton<Random>();
    }
}

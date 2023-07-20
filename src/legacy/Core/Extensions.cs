using Microsoft.Extensions.DependencyInjection;
using Sandbox.CSharp.Core.Modules;

namespace Sandbox.CSharp.Core;

/// <summary>
/// Defines extension methods for simplifying repetitive sandbox module registration.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Adds the core sandbox modules to the service collection.
    /// </summary>
    /// <param name="services">The service collection to add the modules to.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddCoreModules(this IServiceCollection services) => services
        .AddTransient<CoreModule, HelpModule>()
        .AddTransient<CoreModule, VersionModule>();

    /// <summary>
    /// Adds a sandbox module to the service collection.
    /// </summary>
    /// <typeparam name="TModule">The type of the module to add.</typeparam>
    /// <param name="services">The service collection to add the module to.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddModule<TModule>(this IServiceCollection services)
        where TModule : SandboxModule =>
        services.AddTransient<SandboxModule, TModule>();
}

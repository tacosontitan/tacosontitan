using Microsoft.Extensions.DependencyInjection;

namespace Sandbox.CSharp.Core.Console;

/// <summary>
/// Defines extension methods for simplifying console injection.
/// </summary>
public static class ConsoleExtensions
{
    /// <summary>
    /// Adds console services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> with console services added.</returns>
    public static IServiceCollection AddConsole(this IServiceCollection services) => services
        .AddTransient(typeof(IConsole<>), typeof(ModuleConsole<>))
        .AddTransient<IConsole, SandboxConsole>();
}

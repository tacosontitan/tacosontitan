using Microsoft.Extensions.DependencyInjection;

namespace Sandbox.CSharp;

/// <summary>
/// Defines extension methods for dependency injection.
/// </summary>
public static class DependencyExtensions
{
    /// <summary>
    /// Adds the dependencies to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the dependencies to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddDependencies(this IServiceCollection services) => services
        .AddSingleton<Random>();
}

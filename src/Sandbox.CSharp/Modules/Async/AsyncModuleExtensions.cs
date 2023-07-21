using Microsoft.Extensions.DependencyInjection;
using Sandbox.CSharp.Core;

namespace Sandbox.CSharp.Modules.Async;

/// <summary>
/// Defines extension methods for working with the async modules.
/// </summary>
public static class AsyncModuleExtensions
{
    /// <summary>
    /// Adds the <see cref="AsyncEnumerable"/> module to the specified <paramref name="services"/>.
    /// </summary>
    /// <param name="services">The services collection.</param>
    /// <returns>The services collection.</returns>
    public static IServiceCollection AddAsyncModules(this IServiceCollection services) => services
        .AddModule<AsyncEnumerable>()
        .AddModule<AsyncFirstOrDefault>();
}

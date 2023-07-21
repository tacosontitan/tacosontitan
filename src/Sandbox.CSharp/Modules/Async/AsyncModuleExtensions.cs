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

    /// <summary>
    /// Gets the first record from the specified <paramref name="source"/> or a default value if the source is empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the source.</typeparam>
    /// <param name="source">The source.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The first record from the specified <paramref name="source"/> or a default value if the source is empty.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="source"/> is <see langword="null"/>.</exception>
    public static async Task<T?> FirstOrDefaultAsync<T>(this IAsyncEnumerable<T> source, CancellationToken cancellationToken = default)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        await using var sampleEnumerator = source.GetAsyncEnumerator(cancellationToken);
        if (await sampleEnumerator.MoveNextAsync().ConfigureAwait(false))
            return sampleEnumerator.Current;

        return default;
    }
}

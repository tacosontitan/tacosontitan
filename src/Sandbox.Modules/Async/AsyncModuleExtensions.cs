namespace Sandbox.Modules.Async;

/// <summary>
/// Defines extension methods for working with the async modules.
/// </summary>
public static class AsyncModuleExtensions
{
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

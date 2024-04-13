using System.Runtime.CompilerServices;
using Sandbox.Core;
using Sandbox.Core.Diagnostics;

namespace Sandbox.Modules.Async;

/// <summary>
/// Demonstrates how to get the first record or a default value out of an async enumerable.
/// </summary>
public class AsyncFirstOrDefault
    : Module
{
    private static readonly TimeSpan _sampleDelay = TimeSpan.FromMilliseconds(50);
    private readonly IConsumerService _consumerService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncFirstOrDefault"/> class.
    /// </summary>
    /// <param name="consumerService">A service for interacting with consumers.</param>
    public AsyncFirstOrDefault(IConsumerService consumerService) : base(
        key: "async-first",
        name: "Async Enumerable (First or Default)",
        description: "Demonstrates how to get the first record or a default value out of an async enumerable.") =>
        _consumerService = consumerService;

    /// <inheritdoc/>
    public override async Task Invoke(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            await _consumerService.Invoke<CancellationRequestedEvent>(cancellationToken).ConfigureAwait(false);
            return;
        }

        IAsyncEnumerable<int> samples = GetSamples(cancellationToken);
        int? firstSample = await samples.FirstOrDefaultAsync(cancellationToken);
        await _consumerService
            .SendMessage($"The first sample is `{firstSample?.ToString() ?? "null"}`.", cancellationToken)
            .ConfigureAwait(false);
    }

    private async IAsyncEnumerable<int> GetSamples(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        for (int i = 0; i < 25; i++)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                await _consumerService.Invoke<CancellationRequestedEvent>(cancellationToken).ConfigureAwait(false);
                yield break;
            }

            await Task.Delay(_sampleDelay, cancellationToken);
            yield return i;
        }
    }
}

using System.Runtime.CompilerServices;
using Sandbox.Core;
using Sandbox.Core.Diagnostics;

namespace Sandbox.Modules.Async;

/// <summary>
/// Represents a module for tinkering with <see cref="IAsyncEnumerable{T}"/>.
/// </summary>
public class AsyncEnumerable
    : Module
{
    private readonly Random _random;
    private readonly IConsumerService _consumerService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncEnumerable"/> class.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="consumerService">A service for interacting with consumers.</param>
    public AsyncEnumerable(Random random, IConsumerService consumerService) : base(
        key: "async",
        name: "IAsyncEnumerable",
        description: "Demonstrates the use of IAsyncEnumerable.")
    {
        _random = random;
        _consumerService = consumerService;
    }

    /// <inheritdoc/>
    public override async Task Invoke(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            await _consumerService.Invoke<CancellationRequestedEvent>(cancellationToken).ConfigureAwait(false);
            return;
        }

        List<Task> processingTasks = new();
        await foreach (string sample in GetSamples(cancellationToken).ConfigureAwait(false))
        {
            if (cancellationToken.IsCancellationRequested)
            {
                await _consumerService.Invoke<CancellationRequestedEvent>(cancellationToken).ConfigureAwait(false);
                return;
            }

            Task processingTask = ProcessSample(sample, cancellationToken);
            processingTasks.Add(processingTask);
        }

        await Task.WhenAll(processingTasks).ConfigureAwait(false);
    }

    private async IAsyncEnumerable<string> GetSamples(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        for (int i = 0; i < 25; i++)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                await _consumerService.Invoke<CancellationRequestedEvent>(cancellationToken).ConfigureAwait(false);
                yield break;
            }
            
            await Task.Delay(TimeSpan.FromMilliseconds(_random.Next(1, 3) * 150), cancellationToken).ConfigureAwait(false);
            yield return GenerateSample(i);
        }
    }

    private static string GenerateSample(int index)
    {
        int sample = Guid.NewGuid().GetHashCode();
        return $"{index}:{sample:X}";
    }

    private async Task ProcessSample(string sample, CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            await _consumerService.Invoke<CancellationRequestedEvent>(cancellationToken).ConfigureAwait(false);
            return;
        }

        await _consumerService.Whisper(message: $"Processing sample {sample}...", cancellationToken).ConfigureAwait(false);
        await Task.Delay(TimeSpan.FromMilliseconds(_random.Next(5, 15) * 150), cancellationToken).ConfigureAwait(false);
    }
}

using System.Runtime.CompilerServices;
using Sandbox.CSharp.Core;
using Sandbox.CSharp.Core.Console;

namespace Sandbox.CSharp.Modules.Async;

/// <summary>
/// Represents a module for tinkering with <see cref="IAsyncEnumerable"/>.
/// </summary>
public class AsyncEnumerable
    : SandboxModule
{
    private readonly Random _random;
    private readonly IConsole _console;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncEnumerable"/> class.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="console">The console to write messages to.</param>
    public AsyncEnumerable(Random random, IConsole<AsyncEnumerable> console) : base(
        key: "async",
        name: "IAsyncEnumerable",
        description: "Demonstrates the use of IAsyncEnumerable.")
    {
        _random = random;
        _console = console;
    }

    /// <inheritdoc/>
    public override async Task Invoke(CancellationToken cancellationToken = default)
    {
        List<Task> processingTasks = new();
        await foreach (string sample in GetSamples(cancellationToken).ConfigureAwait(false))
        {
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
                _console.WriteLine("Cancellation requested.");
                yield break;
            }

            _console.WriteLine($"Getting sample {i}...");
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
        _console.WriteLine($"Processing sample {sample}...");
        await Task.Delay(TimeSpan.FromMilliseconds(_random.Next(5, 15) * 150), cancellationToken).ConfigureAwait(false);
        _console.WriteLine(sample);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sandbox.CSharp.Core;

namespace Sandbox.CSharp.Modules;

/// <summary>
/// Represents a module for tinkering with <see cref="IAsyncEnumerable"/>.
/// </summary>
public class AsyncEnumerable
    : SandboxModule
{
    private readonly Random _random;
    private readonly ILogger _logger;

    public AsyncEnumerable(ILogger<AsyncEnumerable> logger) : base(
        key: "async",
        name: "IAsyncEnumerable",
        description: "Demonstrates the use of IAsyncEnumerable.")
    {
        _random = new Random();
        _logger = logger;
    }

    /// <inheritdoc/>
    public override async Task Invoke(Guid invocationId, CancellationToken cancellationToken = default)
    {
        List<Task> processingTasks = new();
        await foreach (string sample in GetSamples().WithCancellation(cancellationToken))
        {
            Task processingTask = ProcessSample(invocationId, sample, cancellationToken);
            processingTasks.Add(processingTask);
        }

        await Task.WhenAll(processingTasks);
    }

    private async IAsyncEnumerable<string> GetSamples()
    {
        for (int i = 0; i < 25; i++)
        {
            _logger.LogInformation("Getting sample {Index}...", i);
            await Task.Delay(TimeSpan.FromMilliseconds(_random.Next(1, 3) * 150));
            yield return GenerateSample(i);
        }
    }

    private static string GenerateSample(int index)
    {
        int sample = Guid.NewGuid().GetHashCode();
        return $"{index}:{sample:X}";
    }

    private async Task ProcessSample(Guid invocationId, string sample, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Processing sample {Sample}...", sample);
        await Task.Delay(TimeSpan.FromMilliseconds(_random.Next(5, 15) * 150), cancellationToken);
        WriteLine(invocationId, sample);
    }
}

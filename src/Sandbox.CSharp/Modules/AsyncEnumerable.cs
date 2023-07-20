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
        await foreach (string sample in GetSamples().WithCancellation(cancellationToken))
            WriteLine(invocationId, sample);
    }

    private async IAsyncEnumerable<string> GetSamples()
    {
        for (int i = 0; i < 10; i++)
        {
            _logger.LogInformation("Getting sample {Index}...", i);
            await Task.Delay(TimeSpan.FromSeconds(_random.Next(1, 10)));

            int sample = Guid.NewGuid().GetHashCode();
            yield return $"{i}:{sample:X}";
        }
    }
}

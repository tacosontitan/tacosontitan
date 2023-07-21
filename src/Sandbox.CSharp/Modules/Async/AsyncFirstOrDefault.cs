using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sandbox.CSharp.Core;

namespace Sandbox.CSharp.Modules.Async;

/// <summary>
/// Demonstrates how to get the first record or a default value out of an async enumerable.
/// </summary>
public class AsyncFirstOrDefault
    : SandboxModule
{
    private static readonly TimeSpan _sampleDelay = TimeSpan.FromMilliseconds(50);

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncFirstOrDefault"/> class.
    /// </summary>
    public AsyncFirstOrDefault() : base(
        key: "async-first",
        name: "Async Enumerable (First or Default)",
        description: "Demonstrates how to get the first record or a default value out of an async enumerable.")
    {
    }

    /// <inheritdoc/>
    public override async Task Invoke(Guid invocationId, CancellationToken cancellationToken = default)
    {
        IAsyncEnumerable<int> samples = GetSamples(invocationId);
        await using var sampleEnumerator = samples.GetAsyncEnumerator(cancellationToken);
        if (await sampleEnumerator.MoveNextAsync().ConfigureAwait(false))
        {
            int sample = sampleEnumerator.Current;
            WriteLine(invocationId, $"The first sample is `{sample}`.");
        }

        WriteLine(invocationId, "Done.");
    }

    private async IAsyncEnumerable<int> GetSamples(Guid invocationId)
    {
        for (int i = 0; i < 25; i++)
        {
            WriteLine(invocationId, $"Getting sample {i}...");
            await Task.Delay(_sampleDelay);
            yield return i;
        }
    }
}

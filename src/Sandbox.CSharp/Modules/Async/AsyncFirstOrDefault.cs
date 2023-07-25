using System.Runtime.CompilerServices;
using Sandbox.CSharp.Core;
using Sandbox.CSharp.Core.Console;
using Sandbox.CSharp.Core.Diagnostics;
using Sandbox.CSharp.Core.Diagnostics.Errors;

namespace Sandbox.CSharp.Modules.Async;

/// <summary>
/// Demonstrates how to get the first record or a default value out of an async enumerable.
/// </summary>
public class AsyncFirstOrDefault
    : SandboxModule
{
    private static readonly TimeSpan _sampleDelay = TimeSpan.FromMilliseconds(50);
    private readonly IConsole _console;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncFirstOrDefault"/> class.
    /// </summary>
    /// <param name="console">The console to write messages to.</param>
    public AsyncFirstOrDefault(IConsole<AsyncFirstOrDefault> console) : base(
        key: "async-first",
        name: "Async Enumerable (First or Default)",
        description: "Demonstrates how to get the first record or a default value out of an async enumerable.") =>
        _console = console;

    /// <inheritdoc/>
    public override async Task Invoke(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            _console.RecordEvent<CancellationRequested>();
            return;
        }

        IAsyncEnumerable<int> samples = GetSamples(cancellationToken);
        int? firstSample = await samples.FirstOrDefaultAsync(cancellationToken);
        _console.WriteLine($"The first sample is `{firstSample?.ToString() ?? "null"}`.");
    }

    private async IAsyncEnumerable<int> GetSamples(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        for (int i = 0; i < 25; i++)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _console.RecordEvent<CancellationRequested>();
                yield break;
            }

            _console.WriteLine($"Getting sample {i}...");
            await Task.Delay(_sampleDelay, cancellationToken);
            yield return i;
        }
    }
}

using Microsoft.Extensions.Logging;

namespace Sandbox.CSharp.Core.Diagnostics.Errors;

/// <summary>
/// Represents a <see cref="DiagnosticEvent"/> that is recorded when a cancellation is requested.
/// </summary> 
public class CancellationRequested
    : DiagnosticEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CancellationRequested"/> class.
    /// </summary>
    public CancellationRequested()
        : base(level: LogLevel.Warning)
    { }

    /// <inheritdoc/>
    public override string GenerateMessage() =>
        "The consumer requested cancellation, stopping execution.";
}

using Microsoft.Extensions.Logging;

namespace Sandbox.CSharp.Core.Diagnostics;

/// <summary>
/// Defines a diagnostic event within the sandbox.
/// </summary>
public abstract class DiagnosticEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DiagnosticEvent"/> class.
    /// </summary>
    /// <param name="level">The severity of the event.</param>
    protected DiagnosticEvent(LogLevel level) =>
        Level = level;

    /// <summary>
    /// Gets the log level of the diagnostic event.
    /// </summary>
    public LogLevel Level { get; set; }

    /// <summary>
    /// Prints the diagnostic event.
    /// </summary>
    public abstract string GenerateMessage();
}

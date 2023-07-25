using Microsoft.Extensions.Logging;

namespace Sandbox.CSharp.Core.Diagnostics.Errors;

/// <summary>
/// Represents a <see cref="DiagnosticEvent"/> that is recorded when no module is found.
/// </summary>
public class NoModuleFound
    : DiagnosticEvent
{
    private readonly string _key;

    /// <summary>
    /// Initializes a new instance of the <see cref="NoModuleFound"/> class.
    /// </summary>
    /// <param name="key">The key of the module that was not found.</param>
    public NoModuleFound(string key)
        : base(level: LogLevel.Error) =>
        _key = key;

    /// <inheritdoc/>
    public override string GenerateMessage() =>
        $"No module was found with the specified key `{_key}`.";
}

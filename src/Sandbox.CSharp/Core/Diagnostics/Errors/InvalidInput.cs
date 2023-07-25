using Microsoft.Extensions.Logging;

namespace Sandbox.CSharp.Core.Diagnostics.Errors;

/// <summary>
/// Represents a <see cref="DiagnosticEvent"/> that is recorded when invalid input is received.
/// </summary>
public class InvalidInput
    : DiagnosticEvent
{
    private readonly string _expectation;
    private readonly string _specifiedInput;

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidInput"/> class.
    /// </summary>
    /// <param name="specifiedInput">The input specified by the consumer that is considered invalid.</param>
    /// <param name="expectation">Recommendations or expectations for the consumer.</param>
    public InvalidInput(
        string specifiedInput,
        string expectation)
        : base(level: LogLevel.Error)
    {
        _expectation = expectation;
        _specifiedInput = specifiedInput;
    }

    /// <inheritdoc/>
    public override string GenerateMessage() =>
        $"The specified input `{_specifiedInput}` is invalid. {_expectation}".Trim();
}

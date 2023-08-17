using Microsoft.Extensions.Logging;

namespace Sandbox.Core.Diagnostics;

/// <summary>
/// Represents that invalid input was received.
/// </summary>
public class InvalidInputEvent
    : IEvent
{
    private readonly object? _inputReceived;
    private readonly IConsumerService _consumerService;

    /// <summary>
    /// Creates a new <see cref="InvalidInputEvent"/> event.
    /// </summary>
    /// <param name="inputReceived">The input that was received.</param>
    /// <param name="consumerService">A service for interacting with consumers.</param>
    public InvalidInputEvent(object? inputReceived, IConsumerService consumerService)
    {
        _inputReceived = inputReceived;
        _consumerService = consumerService;
    }

    /// <inheritdoc/>
    public async Task Invoke(CancellationToken cancellationToken = default)
    {
        string dataString = _inputReceived?.ToString() ?? "null";
        string message = $"The specified input `{dataString}` is invalid.";
        await _consumerService
            .Whisper(message, cancellationToken)
            .ConfigureAwait(false);
    }
}

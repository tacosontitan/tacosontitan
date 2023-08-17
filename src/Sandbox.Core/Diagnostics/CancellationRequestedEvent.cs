namespace Sandbox.Core.Diagnostics;

/// <summary>
/// Represents that cancellation has been requested.
/// </summary>
public class CancellationRequestedEvent
    : IEvent
{
    private readonly IConsumerService _consumer;
    private const string Message = "The consumer requested cancellation, stopping execution.";
    
    /// <summary>
    /// Creates a new <see cref="CancellationRequestedEvent"/> instance.
    /// </summary>
    /// <param name="consumer">A consumer service for relaying cancellation information.</param>
    public CancellationRequestedEvent(IConsumerService consumer) =>
        _consumer = consumer;
    
    /// <inheritdoc/>
    public async Task Invoke(CancellationToken cancellationToken = default) => await _consumer
        .SendMessage(Message, CommunicationLevel.Whisper, cancellationToken)
        .ConfigureAwait(false);
}

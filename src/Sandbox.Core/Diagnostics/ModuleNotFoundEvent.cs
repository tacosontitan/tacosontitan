namespace Sandbox.Core.Diagnostics;

/// <summary>
/// Represents that no module was found.
/// </summary>
public class ModuleNotFoundEvent
    : IEvent
{
    private readonly string? _specifiedKey;
    private readonly IConsumerService _consumerService;
    
    /// <summary>
    /// Creates a new <see cref="ModuleNotFoundEvent"/> event.
    /// </summary>
    /// <param name="specifiedKey">The specified key.</param>
    /// <param name="consumerService">A service for interacting with consumers.</param>
    public ModuleNotFoundEvent(string? specifiedKey, IConsumerService consumerService)
    {
        _specifiedKey = specifiedKey;
        _consumerService = consumerService;
    }

    /// <inheritdoc/>
    public async Task Invoke(CancellationToken cancellationToken = default)
    {
        string message = $"No module was found with the specified key `{_specifiedKey}`.";
        await _consumerService
            .Whisper(message, cancellationToken)
            .ConfigureAwait(false);
    }
}

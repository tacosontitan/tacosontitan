namespace Sandbox.Core;

/// <summary>
/// Defines extension methods for the <see cref="IConsumerService"/> interface.
/// </summary>
public static class ConsumerServiceExtensions
{
    /// <summary>
    /// Prompts the consumer for input publicly
    /// </summary>
    /// <typeparam name="T">The type to convert the input to.</typeparam>
    /// <param name="source">The <see cref="IConsumerService"/> to extend.</param>
    /// <param name="prompt">The prompt to display to the consumer.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>The input from the consumer.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static Task<T> PromptForInput<T>(
        this IConsumerService source,
        string prompt,
        CancellationToken cancellationToken = default)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        return source.PromptForInput<T>(prompt, CommunicationLevel.Public, cancellationToken);
    }

    /// <summary>
    /// Sends a public message to the consumer.
    /// </summary>
    /// <param name="source">The <see cref="IConsumerService"/> to extend.</param>
    /// <param name="message">The message to send.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static Task SendMessage(
        this IConsumerService source,
        string message,
        CancellationToken cancellationToken = default)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        return source.SendMessage(message, CommunicationLevel.Public, cancellationToken);
    }
    
    /// <summary>
    /// Whispers the specified message to the consumer.
    /// </summary>
    /// <param name="source">The <see cref="IConsumerService"/> to extend.</param>
    /// <param name="message">The message to send.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static Task Whisper(
        this IConsumerService source,
        string message,
        CancellationToken cancellationToken = default)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        return source.SendMessage(message, CommunicationLevel.Whisper, cancellationToken);
    }
}

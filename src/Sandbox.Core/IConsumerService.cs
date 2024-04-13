using Sandbox.Core.Diagnostics;

namespace Sandbox.Core;

/// <summary>
/// Defines members for interacting with consumers.
/// </summary>
public interface IConsumerService
{
    /// <summary>
    /// Gets the <see cref="IServiceProvider"/> for the current instance of the <see cref="IConsumerService"/> interface.
    /// </summary>
    IServiceProvider ServiceProvider { get; }
    
    /// <summary>
    /// Prompts the consumer for input.
    /// </summary>
    /// <typeparam name="T">The type to convert the input to.</typeparam>
    /// <param name="prompt">The prompt to display to the consumer.</param>
    /// <param name="communicationLevel">The level of communication to use.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>The input from the consumer.</returns>
    Task<T> PromptForInput<T>(
        string prompt,
        CommunicationLevel communicationLevel,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a message to the consumer.
    /// </summary>
    /// <param name="message">The message to send.</param>
    /// <param name="communicationLevel">The level of communication to use.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task SendMessage(
        string message,
        CommunicationLevel communicationLevel,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Invokes a specified event.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event to invoke.</typeparam>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Invoke<TEvent>(CancellationToken cancellationToken = default)
        where TEvent : IEvent;
    
    /// <summary>
    /// Invokes a specified event.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event to invoke.</typeparam>
    /// <param name="data">The data to pass to the event.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Invoke<TEvent>(object? data, CancellationToken cancellationToken = default)
        where TEvent : IEvent;
}

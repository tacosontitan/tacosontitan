namespace Sandbox.Core;

/// <summary>
/// Represents an event.
/// </summary>
public interface IEvent
{
    /// <summary>
    /// Invokes the event.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> for handling cancellation requests.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task Invoke(CancellationToken cancellationToken = default);
}

/// <summary>
/// Represents an event.
/// </summary>
/// <typeparam name="T">Specifies the type of data the event requires.</typeparam>
public interface IEvent<in T>
{
    /// <summary>
    /// Invokes the event.
    /// </summary>
    /// <param name="data">The data to pass to the event.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> for handling cancellation requests.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task Invoke(T? data, CancellationToken cancellationToken = default);
}

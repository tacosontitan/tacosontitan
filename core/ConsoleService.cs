namespace Sandbox;

/// <summary>
/// Represents a <see cref="ConsoleService"/>.
/// </summary>
internal sealed class ConsoleService : Communicator {
    /// <summary>
    /// Creates a new instance of a console service.
    /// </summary>
    /// <param name="mediator">The mediator of the service.</param>
    public ConsoleService(Mediator mediator) : base(mediator) { }
    /// <summary>
    /// Writes the incoming data to the console.
    /// </summary>
    /// <param name="data">The data to handle.</param>
    /// <typeparam name="T">The type of the data to handle.</typeparam>
    /// <exception cref="IOException">Thrown if encountered while writing to the console.</exception>
    internal override void HandleIncomingData<T>(T data) => Console.WriteLine(data);
    /// <summary>
    /// Handles an input request from other communicators.
    /// </summary>
    /// <param name="request">The incoming request data.</param>
    /// <typeparam name="TRequest">The type of the request data.</typeparam>
    /// <typeparam name="TResponse">The type of the response data.</typeparam>
    /// <returns>Returns the user's response, converted to the requested type.</returns>
    /// <exception cref="NotSupportedException">Thrown if the provided request type is unsupported.</exception>
    /// <exception cref="IOException">Thrown if encountered while writing/reading to/from the console.</exception>
    /// <exception cref="OutOfMemoryException">Thrown if encountered while reading from the console.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if encountered while reading from the console.</exception>
    /// <exception cref="InvalidCastException">Thrown if encountered while parsing user input to the specified output type.</exception>
    /// <exception cref="FormatException">Thrown if encountered while parsing user input to the specified output type.</exception>
    /// <exception cref="OverflowException">Thrown if encountered while parsing user input to the specified output type.</exception>
    /// <exception cref="ArgumentNullException">Thrown if encountered while parsing user input to the specified output type.</exception>
    internal override TResponse HandleInputRequest<TRequest, TResponse>(TRequest request)
    {
        if (request is string requestMessage) {
            Console.WriteLine(requestMessage);
            Console.Write("> ");

            var input = Console.ReadLine();
            var convertedInput = Convert.ChangeType(input, typeof(TResponse));
            if (convertedInput != null)
                return (TResponse)convertedInput;
        }

        throw new NotSupportedException($"The specified request type of `{typeof(TRequest).Name}` is not supported.");
    }
}
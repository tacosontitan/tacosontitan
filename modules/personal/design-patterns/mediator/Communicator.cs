namespace Sandbox;

/// <summary>
/// An abstract class representing a communicator.
/// </summary>
public abstract class Communicator {
    public Guid Id { get; private set; }
    protected Mediator Mediator { get; private set; }
    public Communicator(Mediator mediator) {
        Id = Guid.NewGuid();
        Mediator = mediator;
    }
    public void Send<T>(T data) => Mediator.Send(this, data);
    public IEnumerable<TResponse> RequestInput<TRequest, TResponse>(TRequest request) {
        foreach (TResponse response in Mediator.RequestInput<TRequest, TResponse>(this, request))
            yield return response;
    }
    internal abstract void HandleIncomingData<T>(T data);
    internal abstract TResponse HandleInputRequest<TRequest, TResponse>(TRequest request);
}
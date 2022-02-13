namespace Sandbox;

internal sealed class UserService : Communicator {
    public UserService(Mediator mediator) : base(mediator) { }
    internal override void HandleIncomingData<T>(T data)
    {
        throw new NotImplementedException();
    }
    internal override TResponse HandleInputRequest<TRequest, TResponse>(TRequest request)
    {
        throw new NotImplementedException();
    }
}
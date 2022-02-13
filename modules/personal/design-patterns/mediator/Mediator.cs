namespace Sandbox.Mediator;

internal sealed class Mediator {
    private Dictionary<Guid, Communicator> _communicators = new();
    public void Register(Communicator communicator) {
        if (!_communicators.ContainsKey(communicator.Id))
            _communicators.Add(communicator.Id, communicator);
    }
    public void Send<T>(Communicator sender, T data) {
        foreach (var recipient in GetRecipients(sender))
            recipient.HandleIncomingData(data);
    }
    public IEnumerable<TResponse> RequestInput<TRequest, TResponse>(Communicator sender, TRequest request) {
        foreach (var recipient in GetRecipients(sender))
            yield return recipient.HandleInputRequest<TRequest, TResponse>(request);
    }

    #region Private Methods

    private IEnumerable<Communicator> GetRecipients(Communicator sender) => _communicators.Where(w => w.Key != sender.Id)
                                                                                          .Select(s => s.Value);

    #endregion

}
namespace Sandbox;
/// <summary>
/// Represents a <see cref="Communicator" /> implementation in the mediator pattern.
/// </summary>
public abstract class Communicator {

    #region Properties

    /// <summary>
    /// The unique identifier for this <see cref="Communicator" /> instance.
    /// </summary>
    public Guid Id { get; private set; }
    /// <summary>
    /// The display name for this <see cref="Communicator" /> instance.
    /// </summary>
    public string DisplayName { get; private set; }
    /// <summary>
    /// The <see cref="Sandbox.Mediator" /> for this <see cref="Communicator" /> instance.
    /// </summary>
    protected Mediator Mediator { get; private set; }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of <see cref="Communicator" /> with the specified display name and <see cref="Sandbox.Mediator" /> instance.
    /// </summary>
    /// <param name="displayName">The display name for this <see cref="Communicator" /> instance.</param>
    /// <param name="mediator">The <see cref="Sandbox.Mediator" /> for this <see cref="Communicator" /> instance.</param>
    public Communicator(string displayName, Mediator mediator) {
        Id = Guid.NewGuid();
        DisplayName = displayName;
        Mediator = mediator;
    }

    #endregion

    #region Public Methods

    public abstract void ProcessData<T>(Communicator sender, T data);
    public abstract TResult ProcessInputRequest<TRequest, TResult>(Communicator sender, TRequest request);

    #endregion

    #region Protected Methods

    protected void SendData<T>(Communicator recipient, T data) { }
    protected bool TryRequestInput<TRequest, TResponse>(Communicator recipient, TRequest request, out TResponse response) {
        response = default;
        return false;
    }

    #endregion

}
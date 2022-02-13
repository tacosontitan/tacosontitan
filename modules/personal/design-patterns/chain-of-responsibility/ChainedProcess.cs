namespace Sandbox.ChainOfResponsibility;

/// <summary>
/// Represents a <see cref="ChainedProcess{T}" />.
/// </summary>
public abstract class ChainedProcess<T> {

    #region Properties

    /// <summary>
    /// The next processor in the chain, if applicable.
    /// </summary>
    protected ChainedProcess<T>? Processor { get; set; }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of <see cref="ChainedProcess{T}" />.
    /// </summary>
    /// <param name="processor">The next processor in the chain, if applicable.</param>
    public ChainedProcess(ChainedProcess<T>? processor) => Processor = processor;

    #endregion

    #region Public Methods

    /// <summary>
    /// If there's another processor in the chain, then pass processing to it.
    /// </summary>
    /// <param name="value">The value to process.</param>
    public virtual void Process(T value) => Processor?.Process(value);

    #endregion

    #region Protected Methods

    /// <summary>
    /// Invokes the data processed event for any observers.
    /// </summary>
    /// <param name="result">The result of processing.</param>
    protected void OnProcessingComplete(object result) => ProcessingComplete?.Invoke(this, result);

    #endregion

    #region Events

    /// <summary>
    /// Invoked when the data sent to the process method has been successfuly processed.
    /// </summary>
    public event EventHandler<object>? ProcessingComplete;

    #endregion

}
namespace ChainOfResponsibility;

/// <summary>
/// Represents a <see cref="WorkerProcess{T}" />.
/// </summary>
internal abstract class WorkerProcess<T> {

    #region Properties

    /// <summary>
    /// The processor of this process, if applicable.
    /// </summary>
    protected WorkerProcess<T>? Processor { get; set; }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of <see cref="WorkerProcess{T}" />.
    /// </summary>
    /// <param name="processor">The processor that should process this process.</param>
    public WorkerProcess(WorkerProcess<T>? processor) => Processor = processor;

    #endregion

    #region Public Methods

    /// <summary>
    /// If a processor is present, then pass processing to it.
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
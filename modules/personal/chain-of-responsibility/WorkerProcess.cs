namespace ChainOfResponsibility;

/// <summary>
/// Represents a <see cref="WorkerProcess{T}" />.
/// </summary>
internal abstract class WorkerProcess<T> {

    #region Properties

    /// <summary>
    /// The processor of this process, if applicable.
    /// </summary>
    protected WorkerProcess<T> Processor { get; set; }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of <see cref="WorkerProcess{T}" />.
    /// </summary>
    /// <param name="processor">The processor that should process this process.</param>
    public WorkerProcess(WorkerProcess<T> processor) => Processor = processor;

    #endregion

    #region Public Methods

    /// <summary>
    /// If a processor is present, then pass processing to it.
    /// </summary>
    /// <param name="value">The value to pass to the processor.</param>
    public virtual void Process(T value)
    {
        if (Processor != null)
            Processor.Process(value);
    }

    #endregion

}
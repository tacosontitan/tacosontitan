namespace ChainOfResponsibility.FizzBuzz;

/// <summary>
/// Represents the fallback case of fizz buzz as a <see cref="WorkerProcess{T}" /> by simply passing an input value as output.
/// </summary>
internal sealed class OutputWorker : WorkerProcess<int> {
    
    #region Constructor

    /// <summary>
    /// Creates a new instance of <see cref="OutputWorker" />.
    /// </summary>
    public OutputWorker() : base(null) { }

    #endregion

    #region Public Methods

    /// <summary>
    /// Process the input as output per the rules of fizz buzz.
    /// </summary>
    public override void Process(int value) => OnProcessingComplete(value);

    #endregion

}
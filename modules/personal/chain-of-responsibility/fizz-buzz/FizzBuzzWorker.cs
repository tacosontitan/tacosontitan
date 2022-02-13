namespace ChainOfResponsibility.FizzBuzz;

/// <summary>
/// Represents the `fizz-buzz` case of fizz buzz as a <see cref="ChainedProcess{T}" />.
/// </summary>
internal sealed class FizzBuzzProcessor : ChainedProcess<int> {
    
    #region Constructor

    /// <summary>
    /// Creates a new instance of <see cref="FizzBuzzProcessor" />.
    /// </summary>
    public FizzBuzzProcessor(ChainedProcess<int> processor) : base(processor) { }

    #endregion

    #region Public Methods

    /// <summary>
    /// If the input is a multiple of 3 and 5, then output `buzz`, otherwise pass to the chain.
    /// </summary>
    public override void Process(int value) {
        if (value % 3 == 0 && value % 5 == 0)
            OnProcessingComplete("fizz-buzz");
        else
            base.Process(value);
    }

    #endregion

}
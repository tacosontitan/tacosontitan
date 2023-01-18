namespace Sandbox.ChainOfResponsibility.FizzBuzz;

/// <summary>
/// Represents the `buzz` case of fizz buzz as a <see cref="ChainedProcess{T}" />.
/// </summary>
internal sealed class BuzzProcessor : ChainedProcess<int> {
    
    #region Constructor

    /// <summary>
    /// Creates a new instance of <see cref="BuzzProcessor" />.
    /// </summary>
    public BuzzProcessor(ChainedProcess<int> processor) : base(processor) { }

    #endregion

    #region Public Methods

    /// <summary>
    /// If the input is a multiple of 5 then output `buzz`, otherwise pass to the chain.
    /// </summary>
    public override void Process(int value) {
        if (value % 5 == 0)
            OnProcessingComplete("buzz");
        else
            base.Process(value);
    }

    #endregion

}
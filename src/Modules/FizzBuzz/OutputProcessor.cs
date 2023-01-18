namespace Sandbox.Modules.FizzBuzz.FizzBuzz;

/// <summary>
/// Represents the fallback case of fizz buzz as a <see cref="ChainedProcess{T}" />.
/// </summary>
internal sealed class OutputProcessor : ChainedProcess<int>
{

    #region Constructor

    /// <summary>
    /// Creates a new instance of <see cref="OutputProcessor" />.
    /// </summary>
    public OutputProcessor() : base(null) { }

    #endregion

    #region Public Methods

    /// <summary>
    /// Process the input as output per the rules of fizz buzz.
    /// </summary>
    public override void Process(int value) => OnProcessingComplete(value);

    #endregion

}
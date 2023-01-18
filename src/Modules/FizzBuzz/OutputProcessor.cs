namespace Sandbox.Modules.FizzBuzz;

/// <summary>
/// Represents the fallback case of fizz buzz as a <see cref="ChainedHandler{T}" />.
/// </summary>
internal sealed class OutputProcessor : ChainedHandler<int>
{
    /// <summary>
    /// Creates a new instance of <see cref="OutputProcessor" />.
    /// </summary>
    public OutputProcessor() : base(null) { }
    /// <summary>
    /// Process the input as output per the rules of fizz buzz.
    /// </summary>
    public override void Process(int value) => OnProcessingComplete(value);
}
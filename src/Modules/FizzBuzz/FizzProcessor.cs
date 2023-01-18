namespace Sandbox.Modules.FizzBuzz;

/// <summary>
/// Represents the `fizz` case of fizz buzz as a <see cref="ChainedHandler{T}" />.
/// </summary>
internal sealed class FizzProcessor : ChainedHandler<int>
{
    /// <summary>
    /// Creates a new instance of <see cref="FizzProcessor" />.
    /// </summary>
    public FizzProcessor(ChainedHandler<int> processor) : base(processor) { }
    /// <summary>
    /// If the input is a multiple of 3 then output `fizz`, otherwise pass to the chain.
    /// </summary>
    public override void Process(int value)
    {
        if (value % 3 == 0)
            OnProcessingComplete("fizz");
        else
            base.Process(value);
    }
}
namespace Sandbox.Modules.FizzBuzz;

/// <summary>
/// Represents the `buzz` case of fizz buzz as a <see cref="ChainedHandler{T}" />.
/// </summary>
internal sealed class BuzzProcessor : ChainedHandler<int>
{
    /// <summary>
    /// Creates a new instance of <see cref="BuzzProcessor" />.
    /// </summary>
    public BuzzProcessor(ChainedHandler<int> processor) : base(processor) { }
    /// <summary>
    /// If the input is a multiple of 5 then output `buzz`, otherwise pass to the chain.
    /// </summary>
    public override void Process(int value)
    {
        if (value % 5 == 0)
            OnProcessingComplete("buzz");
        else
            base.Process(value);
    }
}
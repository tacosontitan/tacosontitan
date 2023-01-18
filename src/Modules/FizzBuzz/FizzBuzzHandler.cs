namespace Sandbox.Modules.FizzBuzz;

/// <summary>
/// Represents the `fizz-buzz` case of fizz buzz as a <see cref="ChainedHandler{T}" />.
/// </summary>
internal sealed class FizzBuzzHandler : ChainedHandler<int>
{
    /// <summary>
    /// Creates a new instance of <see cref="FizzBuzzHandler" />.
    /// </summary>
    public FizzBuzzHandler(ChainedHandler<int> processor) : base(processor) { }
    /// <summary>
    /// If the input is a multiple of 3 and 5, then output `buzz`, otherwise pass to the chain.
    /// </summary>
    public override void Process(int value)
    {
        if (value % 3 == 0 && value % 5 == 0)
            OnProcessingComplete("fizz-buzz");
        else
            base.Process(value);
    }
}
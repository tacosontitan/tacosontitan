using Mauve;

namespace Sandbox.Modules.FizzBuzz;

/// <summary>
/// Represents the popular programming test `fizz-buzz` in a way that implements the chain of responsibility design pattern; as a <see cref="ConsumableModule" />.
/// </summary>
[Alias("fizz")]
[Discoverable("Fizz Buzz", "Demonstrates the chain of responsibility pattern using fizz-buzz.")]
internal sealed class FizzBuzzModule : Module
{
    public FizzBuzzModule() : base("fizz", "Fizz Buzz", "Demonstrates the chain of responsibility pattern using fizz-buzz.") { }
    protected override async Task Work()
    {
        // Create the chain; though it seems backwards, think about it from an execution standpoint.
        //      Invocation begins with the `fizz-buzz` condition,
        //      if that fails, it falls back to the `buzz` condition, and so on.
        var outputProcessor = new BasicHandler();
        var fizzProcessor = new FizzHandler(outputProcessor);
        var buzzProcessor = new BuzzHandler(fizzProcessor);
        var fizzBuzzProcessor = new FizzBuzzHandler(buzzProcessor);

        // Handle processing complete event.
        void ChainProcessingComplete(object? sender, object data) =>
            _ = Write(data?.ToString() ?? string.Empty);

        // Subscibe to events.
        outputProcessor.ProcessingComplete += ChainProcessingComplete;
        fizzProcessor.ProcessingComplete += ChainProcessingComplete;
        buzzProcessor.ProcessingComplete += ChainProcessingComplete;
        fizzBuzzProcessor.ProcessingComplete += ChainProcessingComplete;

        // Run through a few integers to test it.
        for (int i = 0; i <= 15; i++)
            fizzBuzzProcessor.Process(i);

        await Task.CompletedTask;
    }
}
namespace ChainOfResponsibility;

/// <summary>
/// Represents the popular programming test `fizz-buzz` in a way that implements the chain of responsibility design pattern; as a <see cref="ConsumableModule" />.
/// </summary>
internal sealed class FizzBuzz : ConsumableModule {
    public FizzBuzz() : base("fizz", "Fizz Buzz", "Demonstrates the chain of responsibility pattern using fizz-buzz.") { }
    public override void Invoke()
    {
        // Create the chain; though it seems backwards, think about it from an execution standpoint.
        //      Invocation begins with the `fizz-buzz` condition,
        //      if that fails, it falls back to the `buzz` condition, and so on.
        var outputProcessor = new OutputProcessor();
        var fizzProcessor = new FizzProcessor(outputProcessor);
        var buzzProcessor = new BuzzProcessor(fizzProcessor);
        var fizzBuzzProcessor = new FizzBuzzProcessor(buzzProcessor);

        // Subscribe to the worker events.
        void ChainProcessingComplete(object? sender, object data) => PostMessage(data?.ToString() ?? string.Empty);
        outputProcessor.ProcessingComplete += ChainProcessingComplete;
        fizzProcessor.ProcessingComplete += ChainProcessingComplete;
        buzzProcessor.ProcessingComplete += ChainProcessingComplete;
        fizzBuzzProcessor.ProcessingComplete += ChainProcessingComplete;

        // Run through a few integers to test it.
        for (int i = 0; i < 15; i++)
            fizzBuzzProcessor.Process(i);
    }
}
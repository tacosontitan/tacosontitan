using ChainOfResponsibility.FizzBuzz;
namespace ChainOfResponsibility;

/// <summary>
/// Represents the popular programming test `fizz-buzz` in a way that implements the chain of responsibility design pattern; as a <see cref="ConsumableModule" />.
/// </summary>
internal sealed class FizzBuzzModule : ConsumableModule {
    public FizzBuzzModule() : base("fizz", "Fizz Buzz", "Demonstrates the chain of responsibility pattern using fizz-buzz.") { }
    public override void Invoke()
    {
        // Create the chain; though it seems backwards, think about it from an execution standpoint.
        //      Invocation begins with the `fizz-buzz` condition,
        //      if that fails, it falls back to the `buzz` condition, and so on.
        var outputWorker = new OutputWorker();
        var fizzWorker = new FizzWorker(outputWorker);
        var buzzWorker = new BuzzWorker(fizzWorker);
        var fizzBuzzWorker = new FizzBuzzWorker(buzzWorker);

        // Subscribe to the worker events.
        void WorkerProcessingComplete(object? sender, object data) => PostMessage(data?.ToString() ?? string.Empty);
        outputWorker.ProcessingComplete += WorkerProcessingComplete;
        fizzWorker.ProcessingComplete += WorkerProcessingComplete;
        buzzWorker.ProcessingComplete += WorkerProcessingComplete;
        fizzBuzzWorker.ProcessingComplete += WorkerProcessingComplete;

        // Run through a few integers to test it.
        for (int i = 0; i < 15; i++)
            fizzBuzzWorker.Process(i);
    }
}
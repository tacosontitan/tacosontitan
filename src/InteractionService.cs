namespace Sandbox;

/// <summary>
/// Represents a <see cref="BackgroundService"/> that handles interactions with consumers.
/// </summary>
internal sealed class InteractionService : BackgroundService
{
    private readonly ILogger _logger;
    public InteractionService(ILogger<InteractionService> logger) => _logger = logger;
    protected override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        // Explain how to get help and exit.
        Console.WriteLine($"If you need help at any point, use the `help` command.");
        Console.WriteLine($"To exit the application, use the `exit` command.");

        // Start the interaction process.
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("");
        }

        return Task.CompletedTask;
    }
}
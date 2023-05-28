using MediatR;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Sandbox;

/// <summary>
/// Represents a <see cref="BackgroundService"/> that handles interactions with consumers.
/// </summary>
internal sealed class InteractionService : BackgroundService
{
    private readonly ILogger _logger;
    private readonly IMediator _mediator;
    public InteractionService(IMediator mediator, ILogger<InteractionService> logger)
    {
        _logger = logger;
        _mediator = mediator;
    }
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        // Explain how to get help and exit.
        Console.WriteLine($"If you need help at any point, use the `help` command.");
        Console.WriteLine($"To exit the application, use the `exit` command.");

        // Start the interaction process.
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.Write($"Enter a module key: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                continue;

            // Request the module and execute it if it exists.
            var request = new ModuleRequest(input);
            Module? response = await _mediator.Send(request, cancellationToken);
            if (response is not null)
                await response.Execute();
        }

        await Task.CompletedTask;
    }
}
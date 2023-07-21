using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sandbox.CSharp.Core.Modules;

namespace Sandbox.CSharp.Core;

/// <summary>
/// Defines a service for triggering sandbox modules.
/// </summary>
public class TriggerService
    : BackgroundService
{
    private readonly ILogger _logger;
    private readonly IEnumerable<SandboxModule> _modules;

    /// <summary>
    /// Initializes a new instance of the <see cref="TriggerService"/> class.
    /// </summary>
    /// <param name="coreModules">All of the core modules available to the sandbox.</param>
    /// <param name="modules">All of the modules available to the sandbox.</param>
    /// <param name="logger">A logger for writing log messages.</param>
    public TriggerService(
        IEnumerable<CoreModule> coreModules,
        IEnumerable<SandboxModule> modules,
        ILogger<TriggerService> logger)
    {
        _logger = logger;
        _modules = coreModules.Concat(modules);
    }

    /// <inheritdoc/>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (!await TryProcessIteration(stoppingToken))
                break;

            await Task.Delay(100, stoppingToken);
        }
    }

    private async Task<bool> TryProcessIteration(CancellationToken cancellationToken)
    {
        Console.Write("Enter a command: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            _logger.LogWarning("No input received.");
            return true;
        }

        SandboxModule? module = _modules.FirstOrDefault(m => m.Key.Equals(input, StringComparison.OrdinalIgnoreCase));
        if (module is null)
        {
            _logger.LogWarning("No module found for input '{input}'.", input);
            return true;
        }

        _logger.LogInformation("Invoking module '{module}'.", module.Key);
        await module.Invoke(Guid.NewGuid(), cancellationToken);
        return true;
    }
}

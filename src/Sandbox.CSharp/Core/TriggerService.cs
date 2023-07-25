using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sandbox.CSharp.Core.Console;
using Sandbox.CSharp.Core.Diagnostics;
using Sandbox.CSharp.Core.Diagnostics.Errors;
using Sandbox.CSharp.Core.Modules;

namespace Sandbox.CSharp.Core;

/// <summary>
/// Defines a service for triggering sandbox modules.
/// </summary>
public class TriggerService
    : BackgroundService
{
    private readonly IConsole _console;
    private readonly IEnumerable<SandboxModule> _modules;

    /// <summary>
    /// Initializes a new instance of the <see cref="TriggerService"/> class.
    /// </summary>
    /// <param name="console">The console to write messages to.</param>
    /// <param name="coreModules">All of the core modules available to the sandbox.</param>
    /// <param name="modules">All of the modules available to the sandbox.</param>
    public TriggerService(
        IConsole console,
        IEnumerable<CoreModule> coreModules,
        IEnumerable<SandboxModule> modules)
    {
        _console = console;
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
        _console.Write("Enter a command: ");
        string? input = _console.ReadLine<string?>();
        if (string.IsNullOrWhiteSpace(input))
        {
            _console.RecordEvent<InvalidInput>(input!, "Please enter a valid command.");
            return true;
        }

        SandboxModule? module = _modules.FirstOrDefault(m => m.Key.Equals(input, StringComparison.OrdinalIgnoreCase));
        if (module is null)
        {
            _console.RecordEvent<NoModuleFound>(input!);
            return true;
        }

        _console.WriteLine($"Invoking module '{module.Key}'.");
        await module.Invoke(cancellationToken);
        return true;
    }
}

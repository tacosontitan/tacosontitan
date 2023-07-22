using Sandbox.CSharp.Core.Console;

namespace Sandbox.CSharp.Core.Modules;

/// <summary>
/// Defines a module for displaying help information.
/// </summary>
public class HelpModule
    : CoreModule
{
    private readonly IConsole _console;
    private readonly IEnumerable<SandboxModule> _modules;

    /// <summary>
    /// Initializes a new instance of the <see cref="Help"/> class.
    /// </summary>
    /// <param name="console">The console to write messages to.</param>
    /// <param name="modules">All of the modules available to the sandbox.</param>
    public HelpModule(
        IConsole<HelpModule> console,
        IEnumerable<SandboxModule> modules) : base(
        key: "help",
        name: "Help",
        description: "Displays help information for the sandbox.")
    {
        _console = console;
        _modules = modules;
    }

    /// <inheritdoc/>
    public override Task Invoke(CancellationToken cancellationToken = default)
    {
        foreach (SandboxModule module in _modules)
        {
            if (cancellationToken.IsCancellationRequested)
                break;

            _console.WriteLine($"{module.Key} - {module.Name}: {module.Description}");
        }

        return Task.CompletedTask;
    }
}

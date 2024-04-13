using System.Text;
using Sandbox.Core.Diagnostics;

namespace Sandbox.Core.Modules;

/// <summary>
/// Defines a module for displaying help information.
/// </summary>
public class HelpModule
    : CoreModule
{
    private readonly IConsumerService _consumerService;
    private readonly IEnumerable<Module> _modules;

    /// <summary>
    /// Initializes a new instance of the <see cref="HelpModule"/> class.
    /// </summary>
    /// <param name="consumerService">A service for interacting with the consumer.</param>
    /// <param name="modules">All of the modules available to the sandbox.</param>
    public HelpModule(
        IConsumerService consumerService,
        IEnumerable<Module> modules) : base(
        key: "help",
        name: "Help",
        description: "Displays help information for the sandbox.")
    {
        var coreModules = new Module[]
        {
            this,
            new VersionModule(consumerService)
        };
        
        _modules = modules.Concat(coreModules);
        _consumerService = consumerService;
    }

    /// <inheritdoc/>
    public override async Task Invoke(CancellationToken cancellationToken = default)
    {
        var builder = new StringBuilder();
        foreach (Module module in _modules)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                await _consumerService.Invoke<CancellationRequestedEvent>(cancellationToken);
                return;
            }

            builder.AppendLine($"{module.Key} - {module.Name}: {module.Description}");
        }

        await _consumerService
            .Whisper(message: builder.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }
}

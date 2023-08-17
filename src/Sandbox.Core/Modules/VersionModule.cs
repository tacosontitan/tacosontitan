using System.Reflection;
using System.Text;

namespace Sandbox.Core.Modules;

/// <summary>
/// Defines a module for displaying version information.
/// </summary>
public class VersionModule
    : CoreModule
{
    private readonly IConsumerService _consumerService;

    /// <summary>
    /// Initializes a new instance of the <see cref="VersionModule"/> class.
    /// </summary>
    /// <param name="consumerService">A service for interacting with the consumer.</param>
    public VersionModule(IConsumerService consumerService) : base(
        key: "version",
        name: "Version",
        description: "Displays version information for the sandbox.") =>
        _consumerService = consumerService;

    /// <inheritdoc/>
    public override async Task Invoke(CancellationToken cancellationToken = default)
    {
        var builder = new StringBuilder();
        var assembly = Assembly.GetExecutingAssembly();
        await GenerateVersionInformationRecursive(builder, assembly, cancellationToken: cancellationToken);
        await _consumerService
            .Whisper(message: builder.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    private async Task GenerateVersionInformationRecursive(
        StringBuilder builder,
        Assembly assembly,
        int depth = 0,
        CancellationToken cancellationToken = default)
    {
        string indent = new(c: ' ', count: depth * 4);
        builder.AppendLine($"{indent}{assembly.GetName().Name} (v{assembly.GetName().Version})");
        foreach (AssemblyName reference in assembly.GetReferencedAssemblies())
        {
            if (cancellationToken.IsCancellationRequested)
            {
                builder.AppendLine("Cancellation requested.");
                break;
            }

            Assembly referencedAssembly = Assembly.Load(reference);
            await GenerateVersionInformationRecursive(builder, referencedAssembly, depth: depth + 1, cancellationToken);
        }
    }
}

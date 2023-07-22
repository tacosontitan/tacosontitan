using System.Reflection;
using Sandbox.CSharp.Core.Console;

namespace Sandbox.CSharp.Core.Modules;

/// <summary>
/// Defines a module for displaying version information.
/// </summary>
public class VersionModule
    : CoreModule
{
    private readonly IConsole _console;

    /// <summary>
    /// Initializes a new instance of the <see cref="VersionModule"/> class.
    /// </summary>
    /// <param name="console">A console for writing log messages.</param>
    public VersionModule(IConsole<VersionModule> console) : base(
        key: "version",
        name: "Version",
        description: "Displays version information for the sandbox.") =>
        _console = console;

    /// <inheritdoc/>
    public override Task Invoke(CancellationToken cancellationToken = default)
    {
        _console.WriteLine("Writing version information.");
        var assembly = Assembly.GetExecutingAssembly();
        if (assembly is null)
        {
            _console.WriteLine("Failed to load the executing assembly.");
            return Task.CompletedTask;
        }

        _console.WriteLine($"{assembly.GetName().Name} (v{assembly.GetName().Version})");
        foreach (AssemblyName reference in assembly.GetReferencedAssemblies())
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _console.WriteLine("Cancellation requested.");
                break;
            }

            Assembly referencedAssembly = Assembly.Load(reference);
            WriteAssemblyInfo(reference, referencedAssembly);
        }

        return Task.CompletedTask;
    }

    private void WriteAssemblyInfo(AssemblyName reference, Assembly assembly)
    {
        if (assembly is null)
        {
            _console.WriteLine($"Failed to load referenced assembly `{reference.FullName}`.");
            return;
        }

        AssemblyName assemblyName = assembly.GetName();
        _console.WriteLine($"    {assemblyName.Name} (v{assemblyName.Version})");
    }
}

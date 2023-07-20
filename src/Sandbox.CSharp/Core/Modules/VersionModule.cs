using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Sandbox.CSharp.Core.Modules;

/// <summary>
/// Defines a module for displaying version information.
/// </summary>
public class VersionModule
    : CoreModule
{
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Version"/> class.
    /// </summary>
    /// <param name="logger">A logger for writing log messages.</param>
    public VersionModule(ILogger<Version> logger) : base(
        key: "version",
        name: "Version",
        description: "Displays version information for the sandbox.") =>
        _logger = logger;

    /// <inheritdoc/>
    public override Task Invoke(Guid invocationId, CancellationToken cancellationToken = default)
    {
        _logger.LogTrace("{InvocationId}: Writing version information.", invocationId);
        var assembly = Assembly.GetExecutingAssembly();
        if (assembly is null)
        {
            _logger.LogError("{InvocationId}: Failed to load the executing assembly.");
            return Task.CompletedTask;
        }

        Console.WriteLine($"    {assembly.GetName().Name} (v{assembly.GetName().Version})");
        foreach (AssemblyName reference in assembly.GetReferencedAssemblies())
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogWarning("{InvocationId}: Cancellation requested.", invocationId);
                break;
            }

            Assembly referencedAssembly = Assembly.Load(reference);
            WriteAssemblyInfo(invocationId, reference, referencedAssembly);
        }

        return Task.CompletedTask;
    }

    private void WriteAssemblyInfo(Guid invocationId, AssemblyName reference, Assembly assembly)
    {
        if (assembly is null)
        {
            _logger.LogError("{InvocationId}: Failed to load referenced assembly `{ReferenceName}`.", invocationId, reference.FullName);
            return;
        }

        AssemblyName assemblyName = assembly.GetName();
        Console.WriteLine($"    {assemblyName.Name} (v{assemblyName.Version}");
    }
}

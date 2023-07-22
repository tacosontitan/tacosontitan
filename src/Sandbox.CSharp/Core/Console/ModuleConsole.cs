namespace Sandbox.CSharp.Core.Console;

/// <summary>
/// Represents a console that writes to the standard output stream.
/// </summary>
/// <typeparam name="TModule">The type of the module.</typeparam>
public class ModuleConsole<TModule>
    : SandboxConsole,
      IConsole<TModule>
    where TModule : SandboxModule
{
    private readonly Guid _instanceId;
    private readonly string _moduleName;

    /// <summary>
    /// Creates a new instance of the <see cref="ModuleConsole{T}"/> class.
    /// </summary>
    public ModuleConsole()
    {
        _instanceId = Guid.NewGuid();
        _moduleName = typeof(TModule).Name;
    }

    /// <inheritdoc/>
    public override IConsole WriteLine(string message) =>
        base.WriteLine($"    {_moduleName} [{_instanceId.GetHashCode():X8}]: {message}");
}
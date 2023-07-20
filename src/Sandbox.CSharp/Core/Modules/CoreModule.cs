namespace Sandbox.CSharp.Core.Modules;

/// <summary>
/// Represents a core <see cref="SandboxModule"/>. 
/// </summary>
public abstract class CoreModule
    : SandboxModule
{
    protected CoreModule(string key, string name, string description)
        : base(key, name, description)
    {
    }
}

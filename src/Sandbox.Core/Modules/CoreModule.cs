namespace Sandbox.Core.Modules;

/// <summary>
/// Represents a core <see cref="Module"/>. 
/// </summary>
public abstract class CoreModule
    : Module
{
    protected CoreModule(string key, string name, string description)
        : base(key, name, description)
    {
    }
}

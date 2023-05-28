using MediatR;

namespace Sandbox;

/// <summary>
/// Represents a request for a <see cref="Module"/>.
/// </summary>
internal class ModuleRequest : IRequest<Module?>
{
    /// <summary>
    /// Represents the key of the module for invocation.
    /// </summary>
    public string Key { get; set; }
    /// <summary>
    /// Creates a new <see cref="ModuleRequest"/> instance.
    /// </summary>
    /// <param name="key">Represents the key of the module for invocation.</param>
    public ModuleRequest(string key) =>
        Key = key;
}
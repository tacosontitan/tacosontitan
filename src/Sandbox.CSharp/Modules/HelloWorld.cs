using Sandbox.CSharp.Core;

namespace Sandbox.CSharp.Modules;

/// <summary>
/// Represents a simple hello world module.
/// </summary>
public class HelloWorld
    : SandboxModule
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HelloWorld"/> class.
    /// </summary>
    public HelloWorld() : base(
        key: "hello",
        name: "Hello World",
        description: "Says hello to the world.")
    {
    }

    /// <inheritdoc/>
    public override Task Invoke(Guid invocationId, CancellationToken cancellationToken = default)
    {
        WriteLine(invocationId, "👋 Hello, world!");
        return Task.CompletedTask;
    }
}

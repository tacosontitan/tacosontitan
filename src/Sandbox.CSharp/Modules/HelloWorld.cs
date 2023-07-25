using Sandbox.CSharp.Core;
using Sandbox.CSharp.Core.Console;
using Sandbox.CSharp.Core.Diagnostics;
using Sandbox.CSharp.Core.Diagnostics.Errors;

namespace Sandbox.CSharp.Modules;

/// <summary>
/// Represents a simple hello world module.
/// </summary>
public class HelloWorld
    : SandboxModule
{
    private readonly IConsole _console;

    /// <summary>
    /// Initializes a new instance of the <see cref="HelloWorld"/> class.
    /// </summary>
    /// <param name="console">The console to write messages to.</param>
    public HelloWorld(IConsole<HelloWorld> console) : base(
        key: "hello",
        name: "Hello World",
        description: "Says hello to the world.") =>
        _console = console;

    /// <inheritdoc/>
    public override Task Invoke(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            _console.RecordEvent<CancellationRequested>();
            return Task.CompletedTask;
        }
        
        _console.WriteLine("👋 Hello, world!");
        return Task.CompletedTask;
    }
}

using Sandbox.Core;
using Sandbox.Core.Diagnostics;

namespace Sandbox.Modules;

/// <summary>
/// Represents a simple hello world module.
/// </summary>
public class HelloWorld
    : Module
{
    private readonly IConsumerService _consumer;

    /// <summary>
    /// Initializes a new instance of the <see cref="HelloWorld"/> class.
    /// </summary>
    /// <param name="consumer">The consumer service.</param>
    public HelloWorld(IConsumerService consumer) : base(
        key: "hello",
        name: "Hello World",
        description: "Says hello to the world.") =>
        _consumer = consumer;

    /// <inheritdoc/>
    public override async Task Invoke(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            await _consumer.Invoke<CancellationRequestedEvent>(cancellationToken);
            return;
        }
        
        await _consumer.SendMessage("👋 Hello, world!", cancellationToken).ConfigureAwait(false);
    }
}

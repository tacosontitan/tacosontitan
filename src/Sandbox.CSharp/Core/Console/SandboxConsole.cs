using SystemConsole = System.Console;

namespace Sandbox.CSharp.Core.Console;

/// <summary>
/// Represents a console that writes to the standard output stream.
/// </summary>
public class SandboxConsole
    : IConsole
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SandboxConsole"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    public SandboxConsole(IServiceProvider serviceProvider) =>
        ServiceProvider = serviceProvider;

    /// <inheritdoc/>
    public IServiceProvider ServiceProvider { get; }

    /// <inheritdoc/>
    public virtual IConsole NewLine()
    {
        SystemConsole.WriteLine();
        return this;
    }

    /// <inheritdoc/>
    public virtual TOut? ReadLine<TOut>()
    {
        string? input = SystemConsole.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
            return default;

        return (TOut)Convert.ChangeType(input, typeof(TOut));
    }

    /// <inheritdoc/>
    public virtual IConsole Write(string message)
    {
        SystemConsole.Write(message);
        return this;
    }

    /// <inheritdoc/>
    public virtual IConsole WriteLine(string message)
    {
        SystemConsole.WriteLine(message);
        return this;
    }
}

namespace Sandbox.CSharp.Core.Console;

/// <summary>
/// Defines methods for interacting with the console.
/// </summary>
public interface IConsole
{
    /// <summary>
    /// Gets the <see cref="IServiceProvider"/> for the current instance of the <see cref="IConsole"/> interface.
    /// </summary>
    IServiceProvider ServiceProvider { get; }

    /// <summary>
    /// Reads a line from the console.
    /// </summary>
    /// <returns>The line read from the console.</returns>
    /// <typeparam name="TOut">The type to convert the line to.</typeparam>
    TOut? ReadLine<TOut>();

    /// <summary>
    /// Writes a message to the console.
    /// </summary>
    /// <param name="message">The message to write.</param>
    /// <returns>The current instance of the <see cref="IConsole"/> interface.</returns>
    IConsole Write(string message);

    /// <summary>
    /// Writes a message to the console.
    /// </summary>
    /// <param name="message">The message to write.</param>
    /// <returns>The current instance of the <see cref="IConsole"/> interface.</returns>
    IConsole WriteLine(string message);

    /// <summary>
    /// Writes an empty line to the console.
    /// </summary>
    /// <returns>The current instance of the <see cref="IConsole"/> interface.</returns>
    IConsole NewLine();
}

/// <summary>
/// Defines methods for interacting with the console.
/// </summary>
/// <typeparam name="TModule">The type of the module.</typeparam>
public interface IConsole<TModule>
    : IConsole
    where TModule : SandboxModule
{

}
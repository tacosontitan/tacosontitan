namespace Sandbox.CSharp.Console;

/// <summary>
/// Defines methods for interacting with the console.
/// </summary>
public interface IConsole
{
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

    /// <summary>
    /// Writes a table to the console.
    /// </summary>
    /// <typeparam name="T">The type of the items in the table.</typeparam>
    /// <param name="items">The items to write.</param>
    /// <param name="headers">The headers for the table.</param>
    /// <returns>The current instance of the <see cref="IConsole"/> interface.</returns>
    IConsole WriteTable<T>(IEnumerable<T> items, params string[] headers);
}

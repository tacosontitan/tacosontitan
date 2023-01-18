using Mauve.Extensibility;

namespace Sandbox;

/// <summary>
/// Represents a module that can be executed.
/// </summary>
internal abstract class Module
{
    /// <summary>
    /// The key for invoking the module.
    /// </summary>
    public string Key { get; private set; }
    /// <summary>
    /// The display name of the module.
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// The description of the module.
    /// </summary>
    public string Description { get; private set; }
    /// <summary>
    /// Creates a new <see cref="Module"/> instance.
    /// </summary>
    /// <param name="key">The key for invoking the module.</param>
    /// <param name="name">The display name of the module.</param>
    /// <param name="description">The description of the module.</param>
    /// <param name="logger">The logger instance for the module.</param>
    public Module(string key, string name, string description)
    {
        Key = key;
        Name = name;
        Description = description;
    }
    /// <summary>
    /// Executes the module's workload.
    /// </summary>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public async Task Execute()
    {
        await Write($"{Name}: Starting execution.");
        await Work();
        await WriteWithColor(ConsoleColor.Cyan, "    Done.");
    }
    /// <summary>
    /// Executes the module's workload.
    /// </summary>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    protected abstract Task Work();
    /// <summary>
    /// Attempts to request input from the user.
    /// </summary>
    /// <typeparam name="T">Specifies the type of data desired from the response.</typeparam>
    /// <param name="prompt">The prompt to display to the user.</param>
    /// <param name="result">The result of parsing the user's response.</param>
    /// <returns><see langword="true"/> if a response was received and parsed successfully, otherwise <see langword="false"/>.</returns>
    protected bool TryRequestInput<T>(string prompt, out T? result)
    {
        result = default;

        try
        {
            Console.Write(prompt);
            string? response = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(response))
            {
                _ = WriteError("Invalid response.");
                return false;
            }

            object convertedResponse = Convert.ChangeType(response, typeof(T));
            result = (T)convertedResponse;
            return true;
        } catch (Exception e)
        {
            _ = WriteError($"Unable to handle user input. {e.FlattenMessages()}");
        }

        return false;
    }
    protected async Task Write(string message) =>
        await WriteWithColor(ConsoleColor.White, message);
    protected async Task WriteSuccess(string message) =>
        await WriteWithColor(ConsoleColor.Green, message);
    protected async Task WriteWarning(string message) =>
        await WriteWithColor(ConsoleColor.Yellow, message);
    protected async Task WriteError(string message) =>
        await WriteWithColor(ConsoleColor.Red, message);
    protected async Task WriteWithColor(ConsoleColor color, string message)
    {
        ConsoleColor incomingColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine($"    {message}");
        Console.ForegroundColor = incomingColor;
        await Task.CompletedTask;
    }
}
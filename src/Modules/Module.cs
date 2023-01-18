using Microsoft.Extensions.Logging;

namespace Sandbox.Modules;

/// <summary>
/// Represents a module that can be executed.
/// </summary>
internal abstract class Module
{
    /// <summary>
    /// The logger instance for the module.
    /// </summary>
    protected ILogger Logger { get; private set; }
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
    public Module(string key, string name, string description, ILogger logger)
    {
        Key = key;
        Name = name;
        Description = description;
        Logger = logger;
    }
    /// <summary>
    /// Executes the module's workload.
    /// </summary>
    /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
    public abstract Task Execute();
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
            Console.WriteLine(prompt);
            string? response = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(response))
            {
                Logger.LogError("Invalid response.");
                return false;
            }

            object convertedResponse = Convert.ChangeType(response, typeof(T));
            result = (T)convertedResponse;
            return true;
        } catch (Exception e)
        {
            Logger.LogError(e, "Unable to handle user input.");
        }

        return false;
    }
}
namespace sandbox;

/// <summary>
/// Represents a consumable module within the sandbox.
/// </summary>
public abstract class ConsumableModule
{

    #region Properties

    /// <summary>
    /// The key that invokes the module.
    /// </summary>
    public string Key { get; set; }
    /// <summary>
    /// The display name for the module.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Describes what the module does.
    /// </summary>
    public string Description { get; set; }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of <see cref="ConsumableModule" /> with the specified key, name, and description.
    /// </summary>
    /// <param name="key">The key that invokes the module.</param>
    /// <param name="name">The display name for the module.</param>
    /// <param name="description">Describes what the module does.</param>
    public ConsumableModule(string key, string name, string description)
    {
        Key = key;
        Name = name;
        Description = description;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Invoke the consumable module.
    /// </summary>
    public abstract void Invoke();

    #endregion

    #region Protected Methods

    /// <summary>
    /// Invokes the message ready event for any observers.
    /// </summary>
    /// <param name="message">The message to post.</param>
    protected void PostMessage(string message) => MessageReady?.Invoke(this, message);
    /// <summary>
    /// Attempts to get the user input using a specified prompt.
    /// </summary>
    /// <param name="prompt">The prompt to be displayed to the user.</param>
    /// <param name="result">The result of the user's input cast to the appropriate type.</param>
    /// <typeparam name="T">Specifies the type which is expected.</typeparam>
    /// <returns><see langword="true"/> if the user's input was successfully captured as the specified type, otherwise <see langword="false"/>.</returns>
    protected bool TryGetUserInput<T>(string prompt, out T? result)
    {
        try
        {
            Console.Write($"Grid Point Generator: {prompt}\n>");
            var userInput = Console.ReadLine();
            if (userInput is not null)
            {
                result = typeof(T).IsEnum
                    ? (T?)Enum.Parse(typeof(T), userInput.ToString(), true)
                    : (T?)Convert.ChangeType(userInput, typeof(T));
                return true;
            }
        }
        catch (Exception e)
        {
            PostMessage($"Unable to parse response. {e.Message}");
        }

        result = default;
        return false;
    }

    #endregion

    #region Events

    /// <summary>
    /// Invoked when a message is ready for consumption.
    /// </summary>
    public event EventHandler<string>? MessageReady;

    #endregion

}
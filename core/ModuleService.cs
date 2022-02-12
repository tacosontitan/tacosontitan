using System.Reflection;
using System.Text;

/// <summary>
/// Represents a <see cref="ModuleService" /> in the sandbox.
/// </summary>
internal sealed class ModuleService {

    #region Fields

    private Dictionary<string, ConsumableModule> modules = new();

    #endregion

    #region Public Methods

    /// <summary>
    /// Discover any modules in the entry assembly that derive from <see cref="ConsumableModule" />.
    /// </summary>
    public void Discover() {
        var entryAssembly = Assembly.GetEntryAssembly();
        var moduleTypes = entryAssembly?.GetTypes()?.Where(type => IsModule(type));
        if (moduleTypes?.Count() > 0) {
            foreach (var moduleType in moduleTypes) {
                try {
                    var instance = Activator.CreateInstance(moduleType);
                    if (instance != null) {
                        var module = instance as ConsumableModule;
                        if (!string.IsNullOrWhiteSpace(module?.Key)) {
                            if (!ModuleKeyExists(module.Key))
                                modules.Add(module.Key, module);
                            else
                                PostError($"Unable to register module `{module.Name}`. A module with the same key `{module.Key}` already exists.");
                        }
                    }
                }
                catch (Exception e) { PostError($"Unable to register module of type `{moduleType}`.", e); }
            }
        }
    }
    /// <summary>
    /// Generate a help message containing the keys and descriptions for all loaded modules.
    /// </summary>
    /// <returns>Returns a complete list of keys and descriptions for all loaded modules.</returns>
    public string GenerateHelpMessage() {
        var moduleDescriptions = modules.Values.Select(s => $"{s.Key} - {s.Description}");
        StringBuilder helpMessageBuilder = new("help - Generates this message with a list of commands.");
        helpMessageBuilder.AppendLine("exit - Exits the application");
        helpMessageBuilder.AppendLine(string.Join('\n', moduleDescriptions));
        return helpMessageBuilder.ToString();
    }
    /// <summary>
    /// Searches for a consumable module containing a key of the specified value.
    /// </summary>
    /// <param name="searchValue">The value to search for.</param>
    /// <param name="module">The module associated with the specified search value.</param>
    /// <returns>Returns `true` if a module was found, otherwise `false`.</returns>
    public bool ContainsModule(string searchValue, out ConsumableModule? module) {
        module = null;

        // Manually iterate instead of using .ContainsKey to ensure casing is ignored.
        if (ModuleKeyExists(searchValue)) {
            module = modules[searchValue];
            return true;
        }

        return false;
    }
    /// <summary>
    /// Attempts to invoke the specified <see cref="ConsumableModule" />.
    /// </summary>
    /// <param name="module">The module to invoke.</param>
    public void Invoke(ConsumableModule? module) {
        if (module != null) {
            try { module.Invoke(); }
            catch (Exception e) { PostError($"An unexpected error occurred while attempting to invoke the `{module.Name}` module.", e); }
        } else
            PostError("No module specified.");
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Is the specified <see cref="Type"/> a derivative of <see cref="ConsumableModule"/>?
    /// </summary>
    /// <param name="type">The type to evaluate.</param>
    /// <returns>Returns `true` if the specified type is a derivative of <see cref="ConsumableModule"/>, otherwise `false`.</returns>
    private bool IsModule(Type type) {
        bool assignable = typeof(ConsumableModule).IsAssignableFrom(type);
        return assignable && !type.IsInterface && !type.IsAbstract;
    }
    /// <summary>
    /// Searches the modules dictionary key collection in a case insensitive way, to determine if the specified value is already registered.
    /// </summary>
    /// <param name="searchValue">The value to search for.</param>
    /// <returns>Returns `true` if the key was found, otherwise `false`.</returns>
    private bool ModuleKeyExists(string searchValue) {
        foreach (var key in modules.Keys)
            if (searchValue?.Equals(key, ignoreCase: true) == true)
                return true;

        return false;
    }
    /// <summary>
    /// Invokes the error occurred event for any observers.
    /// </summary>
    /// <param name="message">The message describing the error occuring.</param>
    private void PostError(string message) => ErrorOccurred?.Invoke(this, message);
    /// <summary>
    /// Invokes the error occurred event for any observers.
    /// </summary>
    /// <param name="message">The message describing the error occuring.</param>
    /// <param name="e">The exception that caused this error.</param>
    private void PostError(string message, Exception e) => ErrorOccurred?.Invoke(this, $"{message} {e.Message}");

    #endregion

    #region Events

    /// <summary>
    /// Invoked when errors occur in the <see cref="ModuleService"/>.
    /// </summary>
    public event EventHandler<string>? ErrorOccurred;

    #endregion

}
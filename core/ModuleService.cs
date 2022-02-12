using System.Reflection;

/// <summary>
/// Represents a <see cref="ModuleService" /> in the sandbox.
/// </summary>
internal sealed class ModuleService
{

    #region Fields

    private Dictionary<string, ConsumableModule> modules = new();

    #endregion

    #region Public Methods

    /// <summary>
    /// Discover any modules in the entry assembly that derive from <see cref="ConsumableModule" />.
    /// </summary>
    public void Discover()
    {
        var entryAssembly = Assembly.GetEntryAssembly();
        var moduleTypes = entryAssembly?.GetTypes()?.Where(type => IsModule(type));
        if (moduleTypes?.Count() > 0)
        {
            foreach (var moduleType in moduleTypes)
            {
                try
                {
                    var instance = Activator.CreateInstance(moduleType);
                    if (instance != null)
                    {
                        var module = instance as ConsumableModule;
                        if (!string.IsNullOrWhiteSpace(module?.Key))
                        {
                            if (!modules.ContainsKey(module.Key))
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

    #endregion

    #region Private Methods

    /// <summary>
    /// Is the specified <see cref="Type"/> a derivative of <see cref="ConsumableModule"/>?
    /// </summary>
    /// <param name="type">The type to evaluate.</param>
    /// <returns>Returns `true` if the specified type is a derivative of <see cref="ConsumableModule"/>, otherwise `false`.</returns>
    private bool IsModule(Type type)
    {
        bool assignable = typeof(ConsumableModule).IsAssignableFrom(type);
        return assignable && !type.IsInterface && !type.IsAbstract;
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
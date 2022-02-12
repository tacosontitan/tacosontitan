using System.Reflection;

/// <summary>
/// Is the specified <see cref="Type"/> a derivative of <see cref="ConsumableModule"/>?
/// </summary>
/// <param name="type">The type to evaluate.</param>
/// <returns>Returns `true` </returns>
bool IsModule(Type type) {
    bool assignable = typeof(ConsumableModule).IsAssignableFrom(type);
    return assignable && !type.IsInterface && !type.IsAbstract;
}

// Discover modules.
var entryAssembly = Assembly.GetEntryAssembly();
var assemblyTypes = entryAssembly?.GetTypes()?.Where(type => IsModule(type));

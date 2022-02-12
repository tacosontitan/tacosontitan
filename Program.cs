using System.Reflection;

/// <summary>
/// Is the specified <see cref="Type"/> a derivative of <see cref="ConsumableModule"/>?
/// </summary>
/// <param name="type">The type to evaluate.</param>
/// <returns>Returns `true` if the specified type is a derivative of <see cref="ConsumableModule"/>, otherwise `false`.</returns>
bool IsModule(Type type) {
    bool assignable = typeof(ConsumableModule).IsAssignableFrom(type);
    return assignable && !type.IsInterface && !type.IsAbstract;
}

// Create a collection to store modules in.
Dictionary<string, ConsumableModule> modules = new();

// Discover modules.
var entryAssembly = Assembly.GetEntryAssembly();
var moduleTypes = entryAssembly?.GetTypes()?.Where(type => IsModule(type));
if (moduleTypes?.Count() > 0) {
    foreach (var moduleType in moduleTypes) {
        try {
            var instance = Activator.CreateInstance(moduleType);
            if (instance != null) {
                var module = instance as ConsumableModule;
                if (!string.IsNullOrWhiteSpace(module?.Key)) {
                    if (!modules.ContainsKey(module.Key))
                        modules.Add(module.Key, module);
                    else
                        Console.WriteLine($"Unable to register module `{module.Name}`. A module with the same key `{module.Key}` already exists.");
                }
            }
        } catch (Exception e) { Console.WriteLine($"Unable to register module of type `{moduleType}`. {e.Message}"); }
    }
}
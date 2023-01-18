using System.Reflection;

using Mauve;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Sandbox
{
    /// <summary>
    /// Represents a factory for creating <see cref="Module"/> instances.
    /// </summary>
    internal sealed class ModuleFactory
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<string, Type> _moduleTypes;
        /// <summary>
        /// Creates a new <see cref="ModuleFactory"/> instance.
        /// </summary>
        /// <param name="serviceProvider">The service provider that should be utilized to create new <see cref="Module"/> instances.</param>
        /// <param name="logger">The logger the factory should utilize to record errors.</param>
        public ModuleFactory(IServiceProvider serviceProvider, ILogger<ModuleFactory> logger)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _moduleTypes = new Dictionary<string, Type>();

            // Get the types we care we can use.
            IEnumerable<Type> types = from type
                                      in Assembly.GetExecutingAssembly().GetTypes()
                                      where !type.IsAbstract && type.IsClass && type.IsSubclassOf(typeof(Module))
                                      select type;

            // Add the types to the dictionary.
            foreach (Type type in types)
            {
                AliasAttribute? alias = type.GetCustomAttribute<AliasAttribute>();
                if (alias is null)
                    continue;

                foreach (string aliasName in alias.Values)
                    _ = _moduleTypes.TryAdd(aliasName, type);
            }
        }
        /// <summary>
        /// Attempts to create a new <see cref="Module"/> instance using the specified key.
        /// </summary>
        /// <param name="key">The key for identifying the module.</param>
        /// <param name="module">The newly created <see cref="Module"/> instance.</param>
        /// <returns><see langword="true"/> if a new <see cref="Module"/> instance was created, otherwise <see langword="false"/>.</returns>
        public bool TryCreate(string key, out Module? module)
        {
            try
            {
                Type type = _moduleTypes[key];
                module = (Module)ActivatorUtilities.CreateInstance(_serviceProvider, type);
                return true;
            } catch (Exception e)
            {
                _logger.LogError(e, $"Unable to create a module instance for the specified key `{key}`.");
            }

            module = default;
            return false;
        }
    }
}

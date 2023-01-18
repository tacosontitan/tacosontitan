using System.Reflection;
using System.Linq;

using Mauve;
using Mauve.Extensibility;

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
        public IReadOnlyCollection<ModuleDescription> ModuleDescriptions { get; private set; }
        /// <summary>
        /// Creates a new <see cref="ModuleFactory"/> instance.
        /// </summary>
        /// <param name="serviceProvider">The service provider that should be utilized to create new <see cref="Module"/> instances.</param>
        /// <param name="logger">The logger the factory should utilize to record errors.</param>
        public ModuleFactory(IServiceProvider serviceProvider, ILogger<ModuleFactory> logger)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            var moduleDescriptions = new List<ModuleDescription>();

            // Get the types we care we can use.
            IEnumerable<Type> types = from type
                                      in Assembly.GetExecutingAssembly().GetTypes()
                                      where !type.IsAbstract && type.IsClass && type.IsSubclassOf(typeof(Module))
                                      select type;

            // Add the types to the dictionary.
            foreach (Type type in types)
            {
                DiscoverableAttribute? discoverable = type.GetCustomAttribute<DiscoverableAttribute>();
                AliasAttribute? alias = type.GetCustomAttribute<AliasAttribute>();
                if (discoverable is null || alias is null)
                    continue;

                foreach (string aliasName in alias.Values)
                    moduleDescriptions.Add(new ModuleDescription(aliasName, discoverable.Name, discoverable.Description, type));
            }

            // Set the descriptions collection.
            ModuleDescriptions = moduleDescriptions;
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
                ModuleDescription? description = ModuleDescriptions.SingleOrDefault(description => description.Key.Equals(key, ignoreCase: true));
                if (description is null)
                    throw new ArgumentException("Unable to locate module with the specified key.");

                Type type = description.Type;
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

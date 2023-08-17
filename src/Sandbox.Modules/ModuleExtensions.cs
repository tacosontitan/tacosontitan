using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Sandbox.Core.Modules;

namespace Sandbox.Modules;

/// <summary>
/// Defines extension methods for registering modules.
/// </summary>
public static class ModuleExtensions
{
    /// <summary>
    /// Adds the modules to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the modules to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddModules(this IServiceCollection services)
    {
        IEnumerable<Type> moduleTypes =
        from type in Assembly.GetExecutingAssembly().GetTypes()
        where !type.IsAbstract && typeof(Module).IsAssignableFrom(type)
        select type;

        foreach (var moduleType in moduleTypes)
            RegisterModule(services, moduleType);

        return RegisterCommonDependencies(services);
    }

    private static void RegisterModule(IServiceCollection services, Type moduleType)
    {
        if (typeof(CoreModule).IsAssignableFrom(moduleType))
            _ = services.AddTransient(typeof(CoreModule), moduleType);
        else
            _ = services.AddTransient(typeof(Module), moduleType);
    }

    private static IServiceCollection RegisterCommonDependencies(IServiceCollection services) => services
        .AddSingleton<Random>();
}
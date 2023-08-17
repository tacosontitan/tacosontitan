using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Sandbox.Core.Modules;

using SandboxModule = Sandbox.Core.Module;

namespace Sandbox.Modules;

/// <summary>
/// Defines extension methods for registering modules.
/// </summary>
public static class ModuleExtensions
{
    /// <summary>
    /// Adds module dependencies to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the dependencies to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddModuleDependencies(this IServiceCollection services) => services
        .AddSingleton<Random>();
    
    /// <summary>
    /// Adds modules from the specified assembly to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="T">The type to use to get the assembly.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the modules to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddModulesFromAssemblyContaining<T>(this IServiceCollection services)
    {
        Assembly assembly = typeof(T).Assembly;
        IEnumerable<Type> moduleTypes =
            from type in assembly.GetTypes()
            where !type.IsAbstract && typeof(SandboxModule).IsAssignableFrom(type)
            select type;

        foreach (var moduleType in moduleTypes)
            RegisterModule(services, moduleType);

        return services;
    }

    private static void RegisterModule(IServiceCollection services, Type moduleType)
    {
        if (typeof(CoreModule).IsAssignableFrom(moduleType))
            _ = services.AddTransient(typeof(CoreModule), moduleType);
        else
            _ = services.AddTransient(typeof(SandboxModule), moduleType);
    }
}
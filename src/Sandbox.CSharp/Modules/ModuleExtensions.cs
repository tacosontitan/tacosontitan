using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sandbox.CSharp.Core;
using Sandbox.CSharp.Modules.Paginator;

namespace Sandbox.CSharp.Modules;

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
    public static IServiceCollection AddModules(this IServiceCollection services) => services
        .AddCoreModules()
        .AddPaginatorModule()
        .AddModule<HelloWorld>()
        .AddModule<AsyncEnumerable>();
}
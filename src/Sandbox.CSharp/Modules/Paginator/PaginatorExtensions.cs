using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sandbox.CSharp.Core;

namespace Sandbox.CSharp.Modules.Paginator;

/// <summary>
/// Defines extension methods for supporting the <see cref="PaginatorModule"/>.
/// </summary>
public static class PaginatorExtensions
{
    /// <summary>
    /// Adds the <see cref="PaginatorModule"/> to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="PaginatorModule"/> to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddPaginatorModule(this IServiceCollection services) => services
        .AddModule<PaginatorModule>();
}
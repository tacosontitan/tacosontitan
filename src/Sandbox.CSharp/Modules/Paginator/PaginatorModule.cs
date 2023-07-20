using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sandbox.CSharp.Core;

namespace Sandbox.CSharp.Modules.Paginator;

/// <summary>
/// Represents a module for tinkering with pagination.
/// </summary>
public class PaginatorModule
    : SandboxModule
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PaginatorModule"/> class.
    /// </summary>
    public PaginatorModule() : base(
        key: "paginator",
        name: "Paginator",
        description: "Tests an idea for generic pagination handling.")
    {
    }

    /// <inheritdoc/>
    public override Task Invoke(Guid invocationId, CancellationToken cancellationToken = default)
    {
        WriteLine(invocationId, "📄 Starting paginator.");
        return Task.CompletedTask;
    }
}
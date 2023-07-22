using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sandbox.CSharp.Core;
using Sandbox.CSharp.Core.Console;

namespace Sandbox.CSharp.Modules.Paginator;

/// <summary>
/// Represents a module for tinkering with pagination.
/// </summary>
public class PaginatorModule
    : SandboxModule
{
    private readonly IConsole _console;

    /// <summary>
    /// Initializes a new instance of the <see cref="PaginatorModule"/> class.
    /// </summary>
    /// <param name="console">The console to write messages to.</param>
    public PaginatorModule(IConsole<PaginatorModule> console) : base(
        key: "paginator",
        name: "Paginator",
        description: "Tests an idea for generic pagination handling.") =>
        _console = console;

    /// <inheritdoc/>
    public override Task Invoke(CancellationToken cancellationToken = default)
    {
        _console.WriteLine("📄 Starting paginator.");
        return Task.CompletedTask;
    }
}
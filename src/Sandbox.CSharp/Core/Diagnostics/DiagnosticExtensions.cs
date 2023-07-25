using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sandbox.CSharp.Core.Console;

namespace Sandbox.CSharp.Core.Diagnostics;

/// <summary>
/// Provides extension methods for working with <see cref="DiagnosticEvent"/> instances.
/// </summary>
public static class DiagnosticExtensions
{
    /// <summary>
    /// Records a <see cref="DiagnosticEvent"/> to the specified <see cref="ILogger"/>.
    /// </summary>
    /// <typeparam name="TEvent">The type of <see cref="DiagnosticEvent"/> to record.</typeparam>
    /// <param name="console">The <see cref="IConsole"/> to record the <see cref="DiagnosticEvent"/> to.</param>
    /// <param name="args">The arguments to use when creating the <see cref="DiagnosticEvent"/>.</param>
    public static void RecordEvent<TEvent>(this IConsole console, params object[] args)
        where TEvent : DiagnosticEvent
    {
        IServiceProvider serviceProvider = console.ServiceProvider;
        TEvent diagnosticEvent = ActivatorUtilities.CreateInstance<TEvent>(serviceProvider, args.ToArray());
        string message = diagnosticEvent.GenerateMessage();
        console.WriteLine(message);
    }
}

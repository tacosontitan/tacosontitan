using MediatR;

namespace Sandbox.Runtime;

/// <summary>
/// Represents a request to get input from the user.
/// </summary>
internal sealed class InputRequest : IRequest<string?>
{
    /// <summary>
    /// The prompt to display to the user.
    /// </summary>
    public string Prompt { get; }
    /// <summary>
    /// Creates a new <see cref="InputRequest"/> instance.
    /// </summary>
    /// <param name="prompt">The prompt to display to the user.</param>
    public InputRequest(string prompt) =>
        Prompt = prompt;
}

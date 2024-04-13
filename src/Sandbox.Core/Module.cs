namespace Sandbox.Core;

/// <summary>
/// Defines a module for testing concepts and theories.
/// </summary>
public abstract class Module
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Module"/> class.
    /// </summary>
    /// <param name="key">The key for the module.</param>
    /// <param name="name">The name of the module.</param>
    /// <param name="description">The description of the module.</param>
    protected Module(string key, string name, string description)
    {
        Key = key;
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Gets the invocation key for the module.
    /// </summary>
    public string Key { get; }

    /// <summary>
    /// Gets the name of the module.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the description of the module.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Invokes the module.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> for handling cancellation requests.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public abstract Task Invoke(CancellationToken cancellationToken = default);
}

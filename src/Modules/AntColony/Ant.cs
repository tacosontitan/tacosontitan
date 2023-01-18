namespace Sandbox.Modules.AntColony;

/// <summary>
/// Represents an <see cref="Ant"/> in the AI challenge.
/// </summary>
internal sealed class Ant
{
    /// <summary>
    /// Is this ant alive?
    /// </summary>
    public bool Alive { get; private set; } = true;
    /// <summary>
    /// Kill the ant.
    /// </summary>
    public void Kill() => Alive = false;
}
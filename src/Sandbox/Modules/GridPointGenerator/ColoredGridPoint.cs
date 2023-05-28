namespace Sandbox.Modules.GridPointGenerator
{
    /// <summary>
    /// Represents a <see cref="GridPoint"/> with a <see cref="ConsoleColor"/> for display purposes.
    /// </summary>
    public class ColoredGridPoint : GridPoint
    {
        /// <summary>
        /// The <see cref="ConsoleColor"/> of this <see cref="GridPoint"/>.
        /// </summary>
        public ConsoleColor Color { get; set; }
    }
}
namespace Sandbox.Modules.AntColony;

/// <summary>
/// Represents a <see cref="Landmark"/> in the AI challenge.
/// </summary>
internal sealed class Landmark
{

    #region Fields

    private readonly Random _random = new();

    #endregion

    #region Properties

    /// <summary>
    /// The unique identifier for this particular landmark.
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// The value this landmark is worth to visitors.
    /// </summary>
    public double Value { get; private set; }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of a <see cref="Landmark"/> with the specified identifier and value.
    /// </summary>
    /// <param name="id">The unique identifier for this particular landmark.</param>
    /// <param name="value">The value this landmark is worth to visitors.</param>
    public Landmark(int id, double value)
    {
        Id = id;
        Value = value;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Visit the landmark.
    /// </summary>
    /// <param name="visitor">The ant visiting the landmark.</param>
    public void Visit(Ant visitor)
    {
        int randomOne = _random.Next(0, Value > 100 ? 1 : 5);
        int randomTwo = _random.Next(0, Value > 100 ? 1 : 5);
        if (randomOne == randomTwo)
            visitor.Kill();
    }

    #endregion

}
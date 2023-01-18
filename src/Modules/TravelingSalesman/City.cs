namespace Sandbox.Modules.TravelingSalesman;

/// <summary>
/// Represents a city.
/// </summary>
internal sealed class City
{

    #region Properties

    public int Id { get; set; }
    public string? Name { get; set; }
    public WorldCoordinate Coordinates { get; set; }

    #endregion

    #region Public Methods

    /// <summary>
    /// Calculate the distance between two cities using the Pythagorean theorem.
    /// </summary>
    /// <param name="a">The left operand.</param>
    /// <param name="b">The right operand.</param>
    /// <returns>Returns the distance between the two specified cities.</returns>
    /// <see href="https://en.wikipedia.org/wiki/Pythagorean_theorem" />
    public double DistanceTo(City destination)
    {
        double x = Coordinates.Longitude - destination.Coordinates.Longitude;
        double y = Coordinates.Latitude - destination.Coordinates.Latitude;
        double sumOfSquares = x * x + y * y;
        return Math.Sqrt(sumOfSquares);
    }

    #endregion

}
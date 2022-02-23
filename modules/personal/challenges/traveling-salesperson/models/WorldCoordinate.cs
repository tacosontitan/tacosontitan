namespace Sandbox.Challenges.TravelingSalesperson;

/// <summary>
/// Represents world coordinates.
/// </summary>
internal struct WorldCoordinate {
    /// <summary>
    /// The distance to the North or South of the equator.
    /// </summary>
    public double Latitude { get; set; }
    /// <summary>
    /// The distance to the East or West of the meridian.
    /// </summary>
    public double Longitude { get; set; }
    /// <summary>
    /// Creates a new instance of <see cref="WorldCoordinate"/> with the specified latitude and longitude.
    /// </summary>
    /// <param name="latitude">The distance to the North or South of the equator.</param>
    /// <param name="longitude">The distance to the East or West of the meridian.</param>
    public WorldCoordinate(double latitude, double longitude) {
        Latitude = latitude;
        Longitude = longitude;
    }
}
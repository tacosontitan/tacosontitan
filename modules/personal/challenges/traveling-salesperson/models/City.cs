namespace Sandbox.Challenges.TravelingSalesperson;

/// <summary>
/// Represents a city.
/// </summary>
internal sealed class City {
    public int Id { get; set; }
    public string Name { get; set; }
    public WorldCoordinate Coordinates { get; set; }
}
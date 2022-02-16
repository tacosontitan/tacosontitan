# Traveling Salesperson

> Given a list of cities and the distances between each pair of cities, what is the shortest possible route that visits each city exactly once and returns to the origin city?

### Data Structures
```csharp
public struct WorldCoordinate {
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
public class City {
    public int Id { get; set; }
    public string Name { get; set; }
    public WorldCoordinate Coordinates { get; set; }
}
```

### Testing Method Signature
```csharp
public List<City> GetShortestPath(List<City> destinations) {

}
```

Your objective is to return a collection of `City` objects in an order that represents the shortest possible path, with an accuracy of 70% or higher. You will have to calculate the distances on your own utilizing the `Coordinates` property of the `City` objects.
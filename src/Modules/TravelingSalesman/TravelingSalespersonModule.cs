using Mauve;
using Mauve.Extensibility;

namespace Sandbox.Modules.TravelingSalesman;

/// <summary>
/// Represents the traveling salesperson problem.
/// </summary>
[Alias("traveler")]
[Discoverable("Traveling Salesperson", "Calculates the shortest path between a specified number of random cities.")]
internal sealed class TravelingSalespersonModule : Module
{
    private readonly Random _random;
    public TravelingSalespersonModule(Random random) :
        base("traveler",
             "Traveling Salesperson",
             "Calculates the shortest path between a specified number of random cities.") =>
        _random = random;
    protected override async Task Work()
    {
        // Request a number of cities to traverse through.
        if (!TryRequestInput("How many cities should the salesperson travel through? ", out byte numberOfCities))
            return;

        // Validate the number of requested cities.
        int cityCount = ChallengeData.CityNames.Length;
        if (numberOfCities > cityCount)
            await WriteError($"There are only `{cityCount}` city names available.");

        // Determine the spread of the cities.
        if (!TryRequestInput("How large of an area, in kilometers, should these cities cover?", out ushort spread))
            return;

        // Generate the cities and inform the user on where they are.
        IEnumerable<City> cities = GenerateCities(numberOfCities, spread);
        foreach (City city in cities)
            await Write($"`{city.Name}` is located at `{city.Coordinates.Latitude}`, `{city.Coordinates.Longitude}`.");

        // Create a new path and print the total distance.
        CityPath path = new(cities);
        await Write($"The distance of traversing these cities in chronological order is `{path.Distance}` kilometers.");

        // Traverse the path.
        RunHeapsAlgorithm(cities);
        RunNearestNeighborAlgorithm(cities);
    }
    private IEnumerable<City> GenerateCities(int threshold, int spread)
    {
        var cities = new List<City>();
        for (int i = 0; i < threshold && i < ChallengeData.CityNames.Length; i++)
        {
            string nextCityName = ChallengeData.CityNames.First(cityName => !cities.Any(city => city.Name.Equals(cityName, ignoreCase: true)));
            if (!string.IsNullOrWhiteSpace(nextCityName))
            {
                var city = new City
                {
                    Id = i,
                    Name = nextCityName,
                    Coordinates = new WorldCoordinate
                    {
                        Latitude = _random.NextDouble() * spread,
                        Longitude = _random.NextDouble() * spread
                    }
                };

                cities.Add(city);
            }
        }

        return cities;
    }
    private void RunHeapsAlgorithm(IEnumerable<City> cities)
    {
        HeapsPathBuilder pathBuilder = new(cities);
        RunPathBuilder(pathBuilder, "Heap's algorithm");
    }
    private void RunNearestNeighborAlgorithm(IEnumerable<City> cities)
    {
        NearestNeighborPathBuilder pathBuilder = new(cities);
        RunPathBuilder(pathBuilder, "The nearest neighbor algorithm");
    }
    private void RunPathBuilder(PathBuilder pathBuilder, string name)
    {
        DateTime startTime = DateTime.Now;
        IEnumerable<CityPath> paths = pathBuilder.GenerateAll();
        TimeSpan elapsedTime = DateTime.Now - startTime;
        _ = WriteSuccess($"{name} generated `{paths.Count()}` paths in `{elapsedTime.TotalSeconds}` second(s).");

        CityPath shortestPath = paths.OrderBy(path => path.Distance).First();
        PrintPath(shortestPath);
    }
    private void PrintPath(CityPath path)
    {
        string[] cities = path.Cities.Select(city => city.Name).ToArray();
        _ = Write($"The shortest path is `{{string.Join(\" -> \", cities)}}` for a total distance of `{{path.Distance}}` kilometers.\"");
    }
}
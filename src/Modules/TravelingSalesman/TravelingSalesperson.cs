namespace Sandbox.Modules.TravelingSalesman;

/// <summary>
/// Represents the traveling salesperson problem.
/// </summary>
internal sealed class TravelingSalesperson : ConsumableModule
{

    #region Fields

    private readonly Random _random;

    #endregion

    #region Constructor

    public TravelingSalesperson() : base("traveler",
                                         "Traveling Salesperson",
                                         "Calculates the shortest path between a specified number of random cities.") =>
        _random = new Random();

    #endregion

    #region Public Methods

    public override void Invoke()
    {
        Console.Write("Traveling Salesperson: How many cities should the salesperson traverse through?\n> ");
        string? userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int numberOfCities))
        {
            int cityCount = ChallengeData.CityNames.Length;
            if (numberOfCities > cityCount)
                PostInvalidInput($"There are only `{cityCount}` city names available.");
            else
            {
                Console.Write("Traveling Salesperson: How large of an area, in kilometers, should these cities cover?\n> ");
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int spread))
                {
                    IEnumerable<City> cities = GenerateCities(numberOfCities, spread);
                    foreach (City city in cities)
                        Console.WriteLine($"Traveling Salesperson: `{city.Name}` is located at `{city.Coordinates.Latitude}`, `{city.Coordinates.Longitude}`.");

                    CityPath path = new(cities);
                    Console.WriteLine($"Traveling Salesperson: The distance of traversing these cities in chronological order is `{path.Distance}` kilometers.");

                    RunHeapsAlgorithm(cities);
                    RunNearestNeighborAlgorithm(cities);
                }
            }
        } else
            PostInvalidInput(userInput ?? string.Empty);
    }

    #endregion

    #region Private Methods

    private void PostInvalidInput(string input) => PostMessage($"The value `{input}` is not a valid integer.");
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
        Console.WriteLine($"Traveling Salesperson: {name} generated `{paths.Count()}` paths in `{elapsedTime.TotalSeconds}` second(s).");

        CityPath shortestPath = paths.OrderBy(path => path.Distance).First();
        PrintPath(shortestPath);
    }
    private void PrintPath(CityPath path)
    {
        string[] cities = path.Cities.Select(city => city.Name).ToArray();
        string message = $"Traveling Salesperson: The shortest path is `{string.Join(" -> ", cities)}` for a total distance of `{path.Distance}` kilometers.";
        Console.WriteLine($"Traveling Salesperson: {message}");
    }

    #endregion

}
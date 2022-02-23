using System;
using System.Collections.Generic;
using System.Linq;

using Sandbox;
using Sandbox.Challenges;
using Sandbox.Challenges.TravelingSalesperson;

namespace Sandbox.Modules;

/// <summary>
/// Represents the traveling salesperson problem.
/// </summary>
internal sealed class TravelingSalesperson : ConsumableModule {

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

    public override void Invoke() {
        Console.Write("Traveling Salesperson: How many cities should the salesperson traverse through?\n> ");
        var userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int x)) {
            int cityCount = ChallengeData.CityNames.Length;
            if (x > cityCount)
                PostInvalidInput($"There are only `{cityCount}` city names available.");
            else {
                IEnumerable<City> cities = GenerateCities(x);
                foreach (City city in cities)
                    Console.WriteLine($"Traveling Salesperson: `{city.Name}` is located at `{city.Coordinates.Latitude}`, `{city.Coordinates.Longitude}`.");
            }
        } else
            PostInvalidInput(userInput ?? string.Empty);
    }

    #endregion

    #region Private Methods

    private void PostInvalidInput(string input) => PostMessage($"The value `{input}` is not a valid integer.");
    private IEnumerable<City> GenerateCities(int threshold) {
        var cities = new List<City>();
        for (int i = 0; i < threshold && i < ChallengeData.CityNames.Length; i++) {
            string nextCityName = ChallengeData.CityNames.First(cityName => !cities.Any(city => city.Name.Equals(cityName, ignoreCase: true)));
            if (!string.IsNullOrWhiteSpace(nextCityName)) {
                var city = new City {
                    Id = i,
                    Name = nextCityName,
                    Coordinates = new WorldCoordinate {
                        Latitude = _random.NextDouble(),
                        Longitude = _random.NextDouble()
                    }
                };

                cities.Add(city);
            }
        }

        return cities;
    }

    #endregion

}
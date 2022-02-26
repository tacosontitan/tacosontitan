using System;
using System.Collections.Generic;
namespace Sandbox.Challenges.TravelingSalesperson;

/// <summary>
/// Represents a path through a collection of cities.
/// </summary>
internal sealed class CityPath {

    #region Fields

    private double? _distance = null;

    #endregion

    #region Properties

    /// <summary>
    /// The distance between all cities in the path, if traversed chronologically.
    /// </summary>
    public double Distance {
        get {
            if (_distance == null) {
                _distance = 0;
                if (Cities?.Count > 0)
                    for (int i = 1; i < Cities.Count; i++)
                        _distance += Cities.ElementAt(i - 1).DistanceTo(Cities.ElementAt(i));
            }

            return _distance ?? 0;
        }
    }
    /// <summary>
    /// The collection of cities this path is for.
    /// </summary>
    public IReadOnlyCollection<City> Cities { get; set; }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of <see cref="CityPath"/> with the specified cities.
    /// </summary>
    /// <param name="cities">The collection of cities this path is for.</param>
    public CityPath(IEnumerable<City> cities) => Cities = cities.ToList().AsReadOnly();

    #endregion

}
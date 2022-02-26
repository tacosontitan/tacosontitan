using System.Collections.Generic;
using System.Linq;

namespace Sandbox.Challenges.TravelingSalesperson;

/// <summary>
/// Represents a <see cref="NearestNeighborPathBuilder"/> that utilizes the nearest neighbor algorithm to generate an "optimal" path.
/// </summary>
/// <see href="https://en.wikipedia.org/wiki/Nearest_neighbour_algorithm"/>
internal sealed class NearestNeighborPathBuilder : PathBuilder {

    #region Constructor

    /// <summary>
    /// Creates a new instance of <see cref="NearestNeighborPathBuilder"/> with the specified cities.
    /// </summary>
    /// <param name="cities">The cities this path builder will use to build paths.</param>
    public NearestNeighborPathBuilder(IEnumerable<City> cities) : base(cities) { }

    #endregion

    #region Public Methods

    public override IEnumerable<CityPath> GenerateAll() {
        return null;
    }

    #endregion

    #region Private Methods

    private City GetNearestCity(City currentCity) {
        return null;
    }

    #endregion

}
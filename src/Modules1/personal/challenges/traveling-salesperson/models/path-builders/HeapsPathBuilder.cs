using System.Collections.Generic;
using System.Linq;

namespace Sandbox.Challenges.TravelingSalesperson;

/// <summary>
/// Represents a <see cref="PathBuilder"/> that utilizes Heap's algorithm to generate all permutations.
/// </summary>
/// <see href="https://en.wikipedia.org/wiki/Heap%27s_algorithm"/>
internal sealed class HeapsPathBuilder : PathBuilder {

    #region Fields

    private double _processedPermutations;
    private readonly double _totalPermutations;

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of <see cref="HeapsPathBuilder"/> with the specified cities.
    /// </summary>
    /// <param name="cities">The cities this path builder will use to build paths.</param>
    public HeapsPathBuilder(IEnumerable<City> cities) : base(cities) {
        _totalPermutations = cities.Count();
        for (int i = cities.Count() - 1; i >= 1; i--)
            _totalPermutations *= i;
    }

    #endregion

    #region Public Methods

    public override IEnumerable<CityPath> GenerateAll() {
        _processedPermutations = 0;
        return GeneratePaths(Cities.Count(), Cities.ToArray());
    }

    #endregion

    #region Private Methods

    private IEnumerable<CityPath> GeneratePaths(int n, City[] cities) {
        if (n == 1)
        {
            OnProgressChanged(++_processedPermutations, _totalPermutations);
            yield return new CityPath(cities);
        } else
        {
            IEnumerable<CityPath> paths = GeneratePaths(n - 1, cities);
            foreach (CityPath path in paths)
                yield return path;

            for (int i = 0; i < n - 1; i++)
            {
                int swapIndex = n % 2 == 0 ? i : 0;
                (cities[swapIndex], cities[n - 1]) = (cities[n - 1], cities[swapIndex]);

                paths = GeneratePaths(n - 1, cities);
                foreach (CityPath path in paths)
                    yield return path;
            }
        }
    }

    #endregion

}
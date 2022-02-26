using System.Collections.Generic;
namespace Sandbox.Challenges.TravelingSalesperson;

/// <summary>
/// Represents a <see cref="PathBuilder"/> that utilizes Heap's algorithm to generate all permutations.
/// </summary>
internal sealed class HeapsPathBuilder : PathBuilder {
    public HeapsPathBuilder(IEnumerable<City> cities) : base(cities) { }
    public override IEnumerable<CityPath> GenerateAll()
    {
        throw new System.NotImplementedException();
    }
}
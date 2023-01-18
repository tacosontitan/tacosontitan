namespace Sandbox.Modules.TravelingSalesman;

/// <summary>
/// Represents a <see cref="PathBuilder"/> object utilized to build paths across a collection of cities.
/// </summary>
internal abstract class PathBuilder
{

    #region Properties

    /// <summary>
    /// The cities this path builder uses to build paths.
    /// </summary>
    public IReadOnlyCollection<City> Cities { get; private set; }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of <see cref="PathBuilder"/> with the specified collection of cities.
    /// </summary>
    /// <param name="cities">The cities this path builder will use to build paths.</param>
    public PathBuilder(IEnumerable<City> cities) => Cities = cities.ToList().AsReadOnly();

    #endregion

    #region Public Methods

    /// <summary>
    /// Generates all possible paths.
    /// </summary>
    /// <returns>Returns a collection of city paths.</returns>
    public abstract IEnumerable<CityPath> GenerateAll();

    #endregion

    #region Events and Handlers

    public delegate void ProgressEventHandler(PathBuilder sender, double @is, double @of);
    public ProgressEventHandler ProgressChanged;
    protected void OnProgressChanged(double @is, double @of) => ProgressChanged?.Invoke(this, @is, @of);

    #endregion

}
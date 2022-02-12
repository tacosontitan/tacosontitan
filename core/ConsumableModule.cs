/// <summary>
/// Represents a consumable module within the sandbox.
/// </summary>
internal abstract class ConsumableModule {

    #region Properties

    /// <summary>
    /// The key that invokes the module.
    /// </summary>
    public string Key { get; set; }
    /// <summary>
    /// The display name for the module.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Describes what the module does.
    /// </summary>
    public string Description { get; set; }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of <see cref="ConsumableModule" /> with the specified key, name, and description.
    /// </summary>
    /// <param name="key">The key that invokes the module.</param>
    /// <param name="name">The display name for the module.</param>
    /// <param name="description">Describes what the module does.</param>
    public ConsumableModule(string key, string name, string description) {
        Key = key;
        Name = name;
        Description = description;
    }

    #endregion

}
/// <summary>
/// Represents module metadata within the sandbox.
/// </summary>
public class ModuleAttribute : Attribute {

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
    /// Creates a new instance of <see cref="ModuleAttribute" /> with the specified key, name, and description.
    /// </summary>
    /// <param name="key">The key that invokes the module.</param>
    /// <param name="name">The display name for the module.</param>
    /// <param name="description">Describes what the module does.</param>
    public ModuleAttribute(string key, string name, string description) {
        Key = key;
        Name = name;
        Description = description;
    }

    #endregion

}
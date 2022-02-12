/// <summary>
/// A collection of simple extension methods to simplify implementations with clarity.
/// </summary>
public static class ExtensionMethods {
    /// <summary>
    /// Determines whether this instance and another specified <see cref="String" object have the same value.
    /// </summary>
    /// <param name="input">The current instance being used for comparison.</param>
    /// <param name="value">The string to compare to this instance.</param>
    /// <param name="ignoreCase">Should casing be ignored in this comparison?</param>
    /// <returns>`true` if the value of the value parameter is the same as the value of this instance; otherwise, `false`. If value is `null`, the method returns `false`.</returns>
    public static bool Equals(this string input, string value, bool ignoreCase = false) {
        StringComparison comparisonRules = StringComparison.CurrentCulture;
        if (ignoreCase)
            comparisonRules = StringComparison.InvariantCultureIgnoreCase;

        return input.Equals(value, comparisonRules);
    }
}
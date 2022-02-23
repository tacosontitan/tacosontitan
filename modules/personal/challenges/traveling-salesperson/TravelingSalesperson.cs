namespace Sandbox.Modules;

/// <summary>
/// Represents the traveling salesperson problem.
/// </summary>
internal sealed class TravelingSalesperson : ConsumableModule {

    #region Constructor

    public TravelingSalesperson() : base("traveler", "Traveling Salesperson", "Calculates the shortest path between a specified number of random cities.") { }

    #endregion

    #region Public Methods

    public override void Invoke() {
        Console.Write("Traveling Salesperson: How many cities should the salesperson traverse through?\n> ");
        var userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int x)) {
            Console.WriteLine("Traveling Salesperson: This feature is coming soon!");
        } else
            PostInvalidInput(userInput ?? string.Empty);
    }

    #endregion

    #region Private Methods

    private void PostInvalidInput(string input) => PostMessage($"The value `{input}` is not a valid integer.");

    #endregion

}
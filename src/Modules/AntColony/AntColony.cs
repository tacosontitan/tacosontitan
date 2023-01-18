namespace Sandbox.Modules.AntColony;

/// <summary>
/// Represents the traveling salesperson problem.
/// </summary>
internal sealed class AntColony : ConsumableModule
{

    #region Fields

    private readonly Random _random = new();

    #endregion

    #region Constructor

    public AntColony() : base("ants", "Ant Colony", "Summons an ant colony to find optimal paths between landmarks.") { }

    #endregion

    #region Public Methods

    public override void Invoke()
    {
        Console.Write("Ant Colony: How many landmarks should the colony evaluate?.\n> ");
        string? userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int landmarkCount))
        {
            List<Landmark> landmarks = new();
            for (int i = 0; i < landmarkCount; i++)
                landmarks.Add(new Landmark(i, _random.NextDouble() * 250));
        } else
            PostInvalidInput(userInput ?? string.Empty);
    }

    #endregion

    #region Private Methods

    private void PostInvalidInput(string input) => PostMessage($"The value `{input}` is not a valid integer.");

    #endregion

}
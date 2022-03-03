using System;
using System.Collections.Generic;
using System.Linq;

using Sandbox;
using Sandbox.Challenges;
using Sandbox.Challenges.AntColony;

namespace Sandbox.Modules;

/// <summary>
/// Represents the traveling salesperson problem.
/// </summary>
internal sealed class AntColony : ConsumableModule {

    #region Constructor

    public AntColony() : base("ants", "Ant Colony", "Summons an ant colony to find optimal paths between landmarks.") { }

    #endregion

    #region Public Methods

    public override void Invoke() {
        Console.Write("Ant Colony: How many landmarks should the colony evaluate?.\n> ");
        var userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int landmarkCount)) {
            
        } else
            PostInvalidInput(userInput ?? string.Empty);
    }

    #endregion

    #region Private Methods

    private void PostInvalidInput(string input) => PostMessage($"The value `{input}` is not a valid integer.");

    #endregion

}
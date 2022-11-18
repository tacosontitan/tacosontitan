using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sandbox;

namespace sandbox.modules.personal.challenges.gridpointgenerator {
    /// <summary>
    /// Represents a <see cref="ConsumableModule"/> which generates a grid of a specified scale using specified colors.
    /// </summary>
    public class GridPointGeneratorModule : ConsumableModule {

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="GridPointGeneratorModule"/> instance.
        /// </summary>
        public GridPointGeneratorModule() :
            base("grid", "Grid Point Generator", "Generates the points on a grid of N size.")
        { }

        #endregion

        #region Public Methods

        public override void Invoke() {
            
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Attempts to get the user input using a specified prompt.
        /// </summary>
        /// <param name="prompt">The prompt to be displayed to the user.</param>
        /// <param name="result">The result of the user's input cast to the appropriate type.</param>
        /// <typeparam name="T">Specifies the type which is expected.</typeparam>
        /// <returns><see langword="true"/> if the user's input was successfully captured as the specified type, otherwise <see langword="false"/>.</returns>
        private bool TryGetUserInput<T>(string prompt, out T? result) {
            try {
                Console.Write($"Grid Point Generator: {prompt}\n>");
                var userInput = Console.ReadLine();
                result = (T?)Convert.ChangeType(userInput, typeof(T));
                return true;
            } catch (Exception e) {
                Console.WriteLine($"Grid Point Generator: {e.Message}");
                result = default;
                return false;
            }
        }
        /// <summary>
        /// Generates a grid with the specified scale using the specified colors.
        /// </summary>
        /// <param name="scale">The scale of the grid.</param>
        /// <param name="colorA">The color to be used for even points.</param>
        /// <param name="colorB">The color to be used for odd points.</param>
        /// <returns>A collection of <see cref="ColoredGridPoint"/> instances representing the full grid.</returns>
        private IEnumerable<ColoredGridPoint> GenerateGrid(int scale, uint colorA, uint colorB) {
            int total = 0;
            for (int x = 0; x < scale; x++) {
                for (int y = 0; y < scale; y++) {
                    var gridPoint = new ColoredGridPoint {
                        X = x,
                        Y = y,
                        Color = total++ % 2 == 0
                            ? colorA
                            : colorB
                    };

                    yield return gridPoint;
                }
            }

            yield break;
        }

        #endregion

    }
}
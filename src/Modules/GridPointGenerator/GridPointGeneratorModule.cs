namespace Sandbox.Modules.GridPointGenerator
{
    /// <summary>
    /// Represents a <see cref="ConsumableModule"/> which generates a grid of a specified scale using specified colors.
    /// </summary>
    public class GridPointGeneratorModule : ConsumableModule
    {

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="GridPointGeneratorModule"/> instance.
        /// </summary>
        public GridPointGeneratorModule() :
            base("grid", "Grid Point Generator", "Generates the points on a grid of N size.")
        { }

        #endregion

        #region Public Methods

        public override void Invoke()
        {
            if (TryGetUserInput("What should the scale of the grid be?", out int gridSize))
            {
                if (gridSize is < 0 or > 5)
                {
                    PostMessage("Only grids between a scale of 1 and 5 are currently supported in the sandbox due to display limitations.");
                    return;
                } else if (TryGetUserInput("What should the color of event points be?", out ConsoleColor evenColor))
                {
                    if (TryGetUserInput("What should the color of odd points be?", out ConsoleColor oddColor))
                    {
                        ConsoleColor previousForegroundColor = Console.ForegroundColor;
                        try
                        {
                            int scale = 0;
                            foreach (ColoredGridPoint gridPoint in GenerateGrid(gridSize, evenColor, oddColor))
                            {
                                Console.ForegroundColor = gridPoint.Color;
                                if (++scale > gridSize)
                                {
                                    scale = 1;
                                    Console.Write(Environment.NewLine);
                                }

                                Console.Write("██");
                            }
                        } catch (Exception e)
                        {
                            PostMessage(e.Message);
                        } finally
                        {
                            Console.ForegroundColor = previousForegroundColor;
                            Console.Write(Environment.NewLine);
                        }
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Generates a grid with the specified scale using the specified colors.
        /// </summary>
        /// <param name="scale">The scale of the grid.</param>
        /// <param name="colorA">The color to be used for even points.</param>
        /// <param name="colorB">The color to be used for odd points.</param>
        /// <returns>A collection of <see cref="ColoredGridPoint"/> instances representing the full grid.</returns>
        private IEnumerable<ColoredGridPoint> GenerateGrid(int scale, ConsoleColor colorA, ConsoleColor colorB)
        {
            int total = 0;
            for (int x = 0; x < scale; x++)
            {
                for (int y = 0; y < scale; y++)
                {
                    var gridPoint = new ColoredGridPoint
                    {
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
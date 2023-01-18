using Mauve;

namespace Sandbox.Modules.GridPointGenerator;
/// <summary>
/// Represents a <see cref="ConsumableModule"/> which generates a grid of a specified scale using specified colors.
/// </summary>
[Alias("grid")]
[Discoverable("Grid Point Generator", "Generates the points on a grid of N size.")]
internal sealed class GridPointGeneratorModule : Module
{
    /// <summary>
    /// Creates a new <see cref="GridPointGeneratorModule"/> instance.
    /// </summary>
    public GridPointGeneratorModule() :
        base("grid", "Grid Point Generator", "Generates the points on a grid of N size.")
    { }
    protected override async Task Work()
    {
        // Request a grid size.
        if (!TryRequestInput("What should the scale of the grid be?", out int gridSize))
            return;

        // Validate the supplied grid size.
        if (gridSize is < 1 or > 5)
        {
            await WriteError("Only grids between a scale of 1 and 5 are currently supported in the sandbox due to display limitations.");
            return;
        }

        // Request the grid colors.
        if (!TryRequestInput("What should the color of even squares be?", out ConsoleColor evenColor) ||
            !TryRequestInput("What should the color of odd squares be?", out ConsoleColor oddColor))
            return;

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
        }
        catch (Exception e)
        {
            await WriteError(e.Message);
        }
        finally
        {
            Console.ForegroundColor = previousForegroundColor;
            Console.Write(Environment.NewLine);
        }

        await Task.CompletedTask;
    }
    /// <summary>
    /// Generates a grid with the specified scale using the specified colors.
    /// </summary>
    /// <param name="scale">The scale of the grid.</param>
    /// <param name="evenColor">The color to be used for even points.</param>
    /// <param name="oddColor">The color to be used for odd points.</param>
    /// <returns>A collection of <see cref="ColoredGridPoint"/> instances representing the full grid.</returns>
    private IEnumerable<ColoredGridPoint> GenerateGrid(int scale, ConsoleColor evenColor, ConsoleColor oddColor)
    {
        int total = 0;
        for (int x = 0; x < scale; x++)
            for (int y = 0; y < scale; y++)
                yield return GenerateGridPoint(x, y, total++, evenColor, oddColor);

        yield break;
    }
    private ColoredGridPoint GenerateGridPoint(int x, int y, int index, ConsoleColor evenColor, ConsoleColor oddColor) =>
        new()
        {
            X = x,
            Y = y,
            Color = index % 2 == 0
                        ? evenColor
                        : oddColor
        };
}
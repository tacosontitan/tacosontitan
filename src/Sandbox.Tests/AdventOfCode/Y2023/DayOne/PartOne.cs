namespace Sandbox.QuickTests.AdventOfCode.Y2023.DayOne;

public sealed partial class Trebuchet
{
    [Fact]
    public void PartOne()
    {
        var input = Data.PartOne;
        Assert.NotNull(input);
        
        var calibrationValues = new List<int>();
        var lines = input.Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            var firstDigit = line.FirstOrDefault(char.IsDigit);
            var lastDigit = line.FirstOrDefault(char.IsDigit);
            var rawValue = $"{firstDigit}{lastDigit}";
            var calibrationValue = int.Parse(rawValue);
            calibrationValues.Add(calibrationValue);
        }

        var sum = calibrationValues.Sum();
        Assert.Equal(expected: 55607, actual: sum);
    }
}
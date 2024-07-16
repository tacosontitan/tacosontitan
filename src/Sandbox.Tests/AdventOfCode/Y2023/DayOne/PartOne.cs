namespace Sandbox.QuickTests.AdventOfCode.Y2023.DayOne;

public sealed class PartOne
{
    [Fact]
    public void DayOne_PartOne()
    {
        var input = Data.PartOne;
        List<int> calibrationValues = new();
        string[] splitters = [Environment.NewLine];
        var lines = input.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            var firstDigit = line.FirstOrDefault(char.IsDigit);
            var lastDigit = line.LastOrDefault(char.IsDigit);
            var rawValue = $"{firstDigit}{lastDigit}";
            var calibrationValue = int.Parse(rawValue);
            calibrationValues.Add(calibrationValue);
        }

        var sum = calibrationValues.Sum();
        Assert.Equal(expected: 55607, actual: sum);
    }
}
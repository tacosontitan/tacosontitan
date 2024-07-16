namespace Sandbox.QuickTests.AdventOfCode.Y2023.DayOne;

public sealed class PartTwo
{
    [Fact]
    public void DayOne_PartTwo()
    {
        var input = Data.PartTwo;
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

        string[] alphaNumbers =
        [
            "one", "two", "three", "four", "five",
            "six", "seven", "eight", "nine", "ten"
        ];
        
        var sum = calibrationValues.Sum();
        Assert.Equal(expected: 55607, actual: sum);
    }
}
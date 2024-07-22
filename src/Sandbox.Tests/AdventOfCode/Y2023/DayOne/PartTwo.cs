using System.Collections.Immutable;

namespace Sandbox.QuickTests.AdventOfCode.Y2023.DayOne;

public sealed partial class Trebuchet
{
    private readonly static ImmutableArray<string> AlphaDigits =
    [
        "zero", "one", "two", "three",
        "four", "five", "six", "seven",
        "eight", "nine"
    ];
    
    [Fact]
    public void PartTwo()
    {
        var input = Data.PartTwo;
        Assert.NotNull(input);
        
        var calibrationValues = new List<int>();
        var lines = input.Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            var firstDigit = GetFirstDigit(line);
            var lastDigit = GetLastDigit(line);
            var rawValue = $"{firstDigit}{lastDigit}";
            var calibrationValue = int.Parse(rawValue);
            calibrationValues.Add(calibrationValue);
        }

        var sum = calibrationValues.Sum();
        Assert.Equal(expected: 55607, actual: sum);
    } 

    private static int GetFirstDigit(string input)
    {
        var firstAlphaDigit = AlphaDigits.FirstOrDefault(input.Contains);
        var firstDigit = 
    }

    private static int GetLastDigit(
        string input,
        bool useAlphaDigits)
    {
        if (!useAlphaDigits)
        {
            var lastDigit = input.LastOrDefault(char.IsDigit);
            return int.Parse(lastDigit.ToString());
        }
        
        var lastAlphaDigit = AlphaDigits.LastOrDefault(input.Contains);
        if (lastAlphaDigit is null)
            throw new InvalidOperationException("No alpha digit found in input.");
        
        return AlphaDigits.IndexOf(lastAlphaDigit);
    }
}
using Xunit;

namespace Sandbox.QuickTests.Logic;

public class ChainedNestedValueChecks
{
    [Theory]
    [InlineData(6, true)]
    [InlineData(3, false)]
    public void Foo_NotNull_BarEvaluationReturnsTrue(int bar, bool expectedResult)
    {
        var sample = new Sample
        {
            Foo = new Foo { Bar = bar }
        };

        var actualResult = CheckSample(sample);
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Foo_BarUnderThreshold_ReturnsFalse()
    {
        var sample = new Sample
        {
            Foo = new Foo { Bar = 3 }
        };

        var result = CheckSample(sample);
        Assert.True(result);
    }

    private static bool CheckSample(Sample sample) => sample
        is { Foo.Bar: > 5 }
        or { Fizz.Buzz: > 5 };

    private sealed class Sample
    {
        public Foo? Foo { get; set; }
        public Fizz? Fizz { get; set; }
    }

    private sealed class Foo
    {
        public int Bar { get; set; }
    }

    private sealed class Fizz
    {
        public int Buzz { get; set; }
    }
}

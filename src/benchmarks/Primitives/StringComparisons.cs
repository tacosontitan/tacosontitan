namespace Sandbox.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser]
public class StringComparisons
{
    [Benchmark(Baseline = true)]
    public void EqualsOperator()
    {
        for (var i = 0; i < 1000; i++)
            _ = (i + 1).ToString() == i.ToString();
    }

    [Benchmark]
    public void EqualsMethod()
    {
        for (var i = 0; i < 1000; i++)
            _ = (i + 1).ToString().Equals(i.ToString());
    }
    
    [Benchmark]
    public void EqualsMethodOrdinal()
    {
        for (var i = 0; i < 1000; i++)
            _ = (i + 1).ToString().Equals(i.ToString(), StringComparison.Ordinal);
    }
    
    [Benchmark]
    public void EqualsMethodOrdinalIgnoreCase()
    {
        for (var i = 0; i < 1000; i++)
            _ = (i + 1).ToString().Equals(i.ToString(), StringComparison.OrdinalIgnoreCase);
    }
    
    [Benchmark]
    public void EqualsMethodInvariantCulture()
    {
        for (var i = 0; i < 1000; i++)
            _ = (i + 1).ToString().Equals(i.ToString(), StringComparison.InvariantCulture);
    }
    
    [Benchmark]
    public void EqualsMethodInvariantCultureIgnoreCase()
    {
        for (var i = 0; i < 1000; i++)
            _ = (i + 1).ToString().Equals(i.ToString(), StringComparison.InvariantCultureIgnoreCase);
    }
    
    [Benchmark]
    public void StringEqualsMethod()
    {
        for (var i = 0; i < 1000; i++)
            _ = string.Equals((i + 1).ToString(), i.ToString());
    }
    
    [Benchmark]
    public void StringEqualsMethodOrdinal()
    {
        for (var i = 0; i < 1000; i++)
            _ = string.Equals((i + 1).ToString(), i.ToString(), StringComparison.Ordinal);
    }
    
    [Benchmark]
    public void StringEqualsMethodOrdinalIgnoreCase()
    {
        for (var i = 0; i < 1000; i++)
            _ = string.Equals((i + 1).ToString(), i.ToString(), StringComparison.OrdinalIgnoreCase);
    }
    
    [Benchmark]
    public void StringEqualsMethodInvariantCulture()
    {
        for (var i = 0; i < 1000; i++)
            _ = string.Equals((i + 1).ToString(), i.ToString(), StringComparison.InvariantCulture);
    }
    
    [Benchmark]
    public void StringEqualsMethodInvariantCultureIgnoreCase()
    {
        for (var i = 0; i < 1000; i++)
            _ = string.Equals((i + 1).ToString(), i.ToString(), StringComparison.InvariantCultureIgnoreCase);
    }
    
    [Benchmark]
    public void StringComparerOrdinalEquals()
    {
        for (var i = 0; i < 1000; i++)
            _ = StringComparer.Ordinal.Equals((i + 1).ToString(), i.ToString());
    }
    
    [Benchmark]
    public void StringComparerOrdinalIgnoreCaseEquals()
    {
        for (var i = 0; i < 1000; i++)
            _ = StringComparer.OrdinalIgnoreCase.Equals((i + 1).ToString(), i.ToString());
    }
    
    [Benchmark]
    public void StringComparerInvariantCultureEquals()
    {
        for (var i = 0; i < 1000; i++)
            _ = StringComparer.InvariantCulture.Equals((i + 1).ToString(), i.ToString());
    }
    
    [Benchmark]
    public void StringComparerInvariantCultureIgnoreCaseEquals()
    {
        for (var i = 0; i < 1000; i++)
            _ = StringComparer.InvariantCultureIgnoreCase.Equals((i + 1).ToString(), i.ToString());
    }
}
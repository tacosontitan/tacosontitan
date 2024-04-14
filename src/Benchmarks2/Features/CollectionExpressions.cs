using System.Diagnostics.CodeAnalysis;

namespace Sandbox.Benchmarks;

[MemoryDiagnoser]
public class CollectionExpressions
{
    [Benchmark]
    [SuppressMessage("ReSharper", "UseCollectionExpression", Justification = "This is a benchmark for collection expressions.")]
    [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Benchmark methods cannot be static.")]
    public List<string> InitializationSyntaxWithCapacity() =>
        new(capacity: 3) { "foo", "bar", "baz" };
    
    [Benchmark]
    [SuppressMessage("ReSharper", "UseCollectionExpression", Justification = "This is a benchmark for collection expressions.")]
    [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Benchmark methods cannot be static.")]
    public List<string> InitializationSyntax() =>
        new() { "foo", "bar", "baz" };

    [Benchmark(Baseline = true)]
    [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Benchmark methods cannot be static.")]
    public List<string> ExpressionSyntax() =>
            ["foo", "bar", "baz"];
}
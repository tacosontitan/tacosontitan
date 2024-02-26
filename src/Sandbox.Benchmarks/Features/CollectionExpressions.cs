using BenchmarkDotNet.Attributes;

namespace Sandbox.Benchmarks.Features;

[MemoryDiagnoser]
public class CollectionExpressions
{
    [Benchmark]
    public List<string> InitializationSyntax() =>
        new() { "foo", "bar", "baz" };
    
    [Benchmark]
    public List<string> InitializationSyntaxWithCapacity() =>
        new(capacity: 3) { "foo", "bar", "baz" };

    [Benchmark]
    public List<string> ExpressionSyntax() =>
            ["foo", "bar", "baz"];
}
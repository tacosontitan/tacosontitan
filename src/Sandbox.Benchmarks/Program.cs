using BenchmarkDotNet.Running;
using Sandbox.Benchmarks;

_ = BenchmarkRunner.Run<StringComparisons>();
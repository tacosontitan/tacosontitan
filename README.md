# 🏖️ Just a Sandbox 📦

Do you ever get tired of creating new projects to test out new ideas, concepts, or theories? Well, so do I! Now, I simply create a new module, register it with the dependency injection container, and boot it up.

![image](https://github.com/tacosontitan/sandbox/assets/65432314/07b74e1f-b809-45d2-b6cf-7800db7efb4c)

*Welcome to my sandbox, wanna play?*

## Benchmark Results

### Collection Expressions

| Method                           |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|----------------------------------|---------:|---------:|---------:|-------:|----------:|
| InitializationSyntax             | 24.56 ns | 1.008 ns | 2.973 ns | 0.0421 |      88 B |
| InitializationSyntaxWithCapacity | 16.04 ns | 0.500 ns | 1.474 ns | 0.0382 |      80 B |
| ExpressionSyntax                 | 19.60 ns | 0.572 ns | 1.687 ns | 0.0421 |      88 B |

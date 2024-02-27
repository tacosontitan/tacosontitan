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

### String Comparisons

| Method                                         |     Mean |     Error |   StdDev | Ratio | RatioSD |    Gen0 | Allocated | Alloc Ratio |
|------------------------------------------------|---------:|----------:|---------:|------:|--------:|--------:|----------:|------------:|
| EqualsOperator                                 | 19.26 us |  44.92 us | 2.462 us |  1.00 |    0.00 | 21.4233 |  43.78 KB |        1.00 |
| EqualsMethod                                   | 18.24 us |  40.04 us | 2.195 us |  0.96 |    0.22 | 21.4233 |  43.78 KB |        1.00 |
| EqualsMethodOrdinal                            | 17.42 us |  34.22 us | 1.876 us |  0.91 |    0.11 | 21.4233 |  43.78 KB |        1.00 |
| EqualsMethodOrdinalIgnoreCase                  | 19.42 us |  27.24 us | 1.493 us |  1.01 |    0.08 | 21.4233 |  43.78 KB |        1.00 |
| EqualsMethodInvariantCulture                   | 77.50 us |  81.18 us | 4.450 us |  4.08 |    0.69 | 21.3623 |  43.78 KB |        1.00 |
| EqualsMethodInvariantCultureIgnoreCase         | 78.90 us | 124.44 us | 6.821 us |  4.16 |    0.82 | 21.3623 |  43.78 KB |        1.00 |
| StringEqualsMethod                             | 15.89 us |  14.96 us | 0.820 us |  0.84 |    0.13 | 21.4233 |  43.78 KB |        1.00 |
| StringEqualsMethodOrdinal                      | 17.15 us |  25.20 us | 1.381 us |  0.91 |    0.17 | 21.4233 |  43.78 KB |        1.00 |
| StringEqualsMethodOrdinalIgnoreCase            | 18.18 us |  23.86 us | 1.308 us |  0.95 |    0.06 | 21.4233 |  43.78 KB |        1.00 |
| StringEqualsMethodInvariantCulture             | 79.16 us |  92.77 us | 5.085 us |  4.15 |    0.49 | 21.3623 |  43.78 KB |        1.00 |
| StringEqualsMethodInvariantCultureIgnoreCase   | 74.82 us |  67.35 us | 3.692 us |  3.94 |    0.64 | 21.3623 |  43.78 KB |        1.00 |
| StringComparerOrdinalEquals                    | 17.25 us |  23.82 us | 1.306 us |  0.91 |    0.17 | 21.4233 |  43.78 KB |        1.00 |
| StringComparerOrdinalIgnoreCaseEquals          | 17.75 us |  29.05 us | 1.592 us |  0.93 |    0.17 | 21.4233 |  43.78 KB |        1.00 |
| StringComparerInvariantCultureEquals           | 78.98 us | 134.89 us | 7.394 us |  4.12 |    0.30 | 21.3623 |  43.78 KB |        1.00 |
| StringComparerInvariantCultureIgnoreCaseEquals | 79.19 us |  82.76 us | 4.536 us |  4.15 |    0.53 | 21.3623 |  43.78 KB |        1.00 |

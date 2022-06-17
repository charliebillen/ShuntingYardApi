# Shunting Yard Calculator Benchmarks

Initial results on `main`:
```
BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.4 (21F79) [Darwin 21.5.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), Arm64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), Arm64 RyuJIT


| Method |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
|------- |---------:|----------:|----------:|-------:|----------:|
|  Solve | 1.252 us | 0.0025 us | 0.0023 us | 0.5150 |      1 KB |

```

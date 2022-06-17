using BenchmarkDotNet.Attributes;
using Calculator = ShuntingYard.Core.ShuntingYardCalculator;

namespace ShuntingYardCalculator.Benchmarks;

[MemoryDiagnoser]
public class ShuntingYardCalculatorBenchmark
{
    private readonly Calculator _calculator = new();
    private readonly string _calculation = "((100+200)*(3000-4000))/2";

    [Benchmark]
    public void Solve()
        => _calculator.Solve(_calculation);
}

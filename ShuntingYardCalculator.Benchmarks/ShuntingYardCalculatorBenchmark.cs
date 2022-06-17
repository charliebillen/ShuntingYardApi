using BenchmarkDotNet.Attributes;

namespace ShuntingYardCalculator.Benchmarks;

[MemoryDiagnoser]
public class ShuntingYardCalculatorBenchmark
{
    private readonly ShuntingYard.Core.ShuntingYardCalculator _calculator = new ShuntingYard.Core.ShuntingYardCalculator();
    private readonly string _calculation = "((100+200)*(3000-4000))/2";

    [Benchmark]
    public void Solve()
        => _calculator.Solve(_calculation);
}
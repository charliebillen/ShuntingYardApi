// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using ShuntingYardCalculator.Benchmarks;

BenchmarkRunner.Run<ShuntingYardCalculatorBenchmark>();
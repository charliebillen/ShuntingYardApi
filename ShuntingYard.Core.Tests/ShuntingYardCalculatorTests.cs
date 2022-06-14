namespace ShuntingYard.Core.Tests;

public class ShuntingYardCalculatorTests
{
    [Theory]
    [InlineData("1+2", 3)]
    [InlineData("1-2", -1)]
    [InlineData("1+2*3", 7)]
    [InlineData("1*2/3", 0.667)]
    [InlineData("(1+2)*3", 9)]
    [InlineData("(1+2)*(3+4)", 21)]
    [InlineData("100+200", 300)]
    public void Solve_GivenPostfixCalculation_ReturnsTheResult(string calculation, decimal expected)
    {
        var calculator = new ShuntingYardShuntingYardCalculator();

        var actual = calculator.Solve(calculation);

        actual.Should().BeApproximately(expected, 3);
    }
}

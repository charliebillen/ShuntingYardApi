namespace ShuntingYard.Core.Tests;

public class ShuntingYardCalculatorTests
{
    [Theory]
    [InlineData("1+2", 3)]
    [InlineData("1+2*3", 7)]
    [InlineData("1*2/3", 0.667)]
    [InlineData("(1+2)*3", 9)]
    [InlineData("(1+2)*(3+4)", 21)]
    public void Solve_GivenPostfixCalculation_ReturnsTheResult(string calculation, decimal expected)
    {
        var calculator = new ShuntingYardCalculator();

        var actual = calculator.Solve(calculation);

        actual.Should().BeApproximately(expected, 3);
    }
}

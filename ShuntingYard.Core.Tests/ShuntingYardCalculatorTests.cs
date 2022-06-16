namespace ShuntingYard.Core.Tests;

public class ShuntingYardCalculatorTests
{
    [Theory]
    [InlineData("0", 0)]
    [InlineData("1+2", 3)]
    [InlineData("1-2", -1)]
    [InlineData("1+2*3", 7)]
    [InlineData("1*2/3", 0.667)]
    [InlineData("(1+2)*3", 9)]
    [InlineData("(1+2)*(3+4)", 21)]
    [InlineData("(10*(1+3)+4)/2", 22)]
    [InlineData("100+200", 300)]
    [InlineData("10*2.5", 25)]
    [InlineData("3/1.5", 2)]
    [InlineData("(1+2.5)*(3+4)", 24.5)]
    public void Solve_GivenCalculationString_ReturnsTheResult(string calculation, decimal expected)
    {
        var calculator = new ShuntingYardCalculator();

        var actual = calculator.Solve(calculation);

        actual.Should().BeApproximately(expected, 3);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Solve_GivenNullOrEmpty_ThrowsArgumentException(string calculation)
    {
        var calculator = new ShuntingYardCalculator();

        Action test = () => calculator.Solve(calculation);

        test.Should()
            .Throw<ArgumentException>()
            .WithMessage("Must have a value (Parameter 'calculation')");
    }
}

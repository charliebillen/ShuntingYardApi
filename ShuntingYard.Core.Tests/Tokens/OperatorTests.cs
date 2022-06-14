namespace ShuntingYard.Core.Tests.Tokens;

public class OperatorTests
{
    [Theory]
    [InlineData("1", "2", "+", "3")]
    [InlineData("1", "2", "-", "-1")]
    [InlineData("1", "2", "*", "2")]
    [InlineData("1", "2", "/", "0.5")]
    public void Apply_GivenTwoOperands_ReturnsAnOperandWithCorrectValue(
        string leftVal, 
        string rightVal,
        string operatorType,
        string expected)
    {
        var left = new Operand(leftVal);
        var right = new Operand(rightVal);

        var op = (Operator)TokenFactory.TokenFrom(operatorType);

        var actual = op.Apply(left, right);
        actual.Value.Should().Be(expected);
    }
}
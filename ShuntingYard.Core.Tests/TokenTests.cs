using ShuntingYard.Core.Tokens;

namespace ShuntingYard.Core.Tests;

public class TokenTests
{
    [Theory]
    [InlineData("0", 0, typeof(Operand))]
    [InlineData("(", 0, typeof(LeftParen))]
    [InlineData(")", 0, typeof(RightParen))]
    [InlineData("+", 2, typeof(AdditionOperator))]
    [InlineData("-", 2, typeof(SubtractionOperator))]
    [InlineData("*", 4, typeof(MultiplicationOperator))]
    [InlineData("/", 4, typeof(DivisionOperator))]
    public void From_GivenAStringToken_ReturnsCorrectToken(string input, int precedence, Type tokenType)
    {
        var token = Token.From(input);

        token.Value.Should().Be(input);
        token.Precedence.Should().Be(precedence);
        token.GetType().Should().Be(tokenType);
    }

    [Theory]
    [InlineData("1", "2", "+", "3")]
    [InlineData("1", "2", "-", "-1")]
    [InlineData("1", "2", "*", "2")]
    [InlineData("2", "2", "/", "1")]
    public void Apply_GivenTwoOperands_ReturnsAnOperandWithCorrectValue(
        string leftVal, 
        string rightVal,
        string operatorType,
        string expected)
    {
        var left = new Operand(leftVal);
        var right = new Operand(rightVal);

        var op = (Operator)Token.From(operatorType);

        var actual = op.Apply(left, right);
        actual.Value.Should().Be(expected);
    }
}
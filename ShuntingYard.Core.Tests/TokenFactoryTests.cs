namespace ShuntingYard.Core.Tests;

public class TokenFactoryTests
{
    [Theory]
    [InlineData("0", 0, typeof(Operand))]
    [InlineData("(", 0, typeof(LeftParen))]
    [InlineData(")", 0, typeof(RightParen))]
    [InlineData("+", 2, typeof(AdditionOperator))]
    [InlineData("-", 2, typeof(SubtractionOperator))]
    [InlineData("*", 4, typeof(MultiplicationOperator))]
    [InlineData("/", 4, typeof(DivisionOperator))]
    public void TokenFrom_GivenAStringToken_ReturnsCorrectToken(string input, int precedence, Type tokenType)
    {
        var token = TokenFactory.TokenFrom(input);

        token.Value.Should().Be(input);
        token.Precedence.Should().Be(precedence);
        token.GetType().Should().Be(tokenType);
    }
}
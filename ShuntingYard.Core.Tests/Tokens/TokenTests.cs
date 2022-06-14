namespace ShuntingYard.Core.Tests.Tokens;

public class TokenTests
{
    [Fact]
    public void Operators_CompareTokensAsExpected()
    {
        var multiply = new MultiplicationOperator("*");
        var add = new AdditionOperator("+");
        var operand = new Operand("1");

        var addIsLowerThanMultiply = add <= multiply;
        addIsLowerThanMultiply.Should().BeTrue();

        var operandIsLowerThanAdd = operand <= add;
        operandIsLowerThanAdd.Should().BeTrue();

        var multiplyIsGreaterThanOperand = multiply >= operand;
        multiplyIsGreaterThanOperand.Should().BeTrue();
    }

    [Fact]
    public void Equals_ComparingTokens_ReturnsTheExpectedResult()
    {
        var numberOne = new Operand("1");
        var alsoNumberOne = new Operand("1");
        var numberTwo = new Operand("2");

        numberOne.Equals(numberOne).Should().BeTrue();
        numberOne.Equals(alsoNumberOne).Should().BeTrue();
        numberOne.Equals(numberTwo).Should().BeFalse();
        numberOne.Equals(null).Should().BeFalse();
    }
    
    [Fact]
    public void Equals_ComparingObjects_ReturnsTheExpectedResult()
    {
        var numberOne = new Operand("1");
        var alsoNumberOne = new Operand("1");
        var numberTwo = new Operand("2");

        numberOne.Equals(numberOne as object).Should().BeTrue();
        numberOne.Equals(alsoNumberOne as object).Should().BeTrue();
        numberOne.Equals(numberTwo as object).Should().BeFalse();
        numberOne.Equals(new{}).Should().BeFalse();
        numberOne.Equals((object?)null).Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_ReturnsTheCombinationOfValueAndPrecedence()
    {
        var token = new LeftParen("(");

        var expected = HashCode.Combine(token.Value, token.Precedence);

        token.GetHashCode().Should().Be(expected);
    }
}
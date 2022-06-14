namespace ShuntingYard.Core.Tests.Tokens;

public class OperandTests
{
    [Fact]
    public void ToDecimal_ReturnsTheTokenValueAsDecimal()
    {
        var operand = new Operand("1.234");

        operand.ToDecimal().Should().Be(1.234m);
    }
}
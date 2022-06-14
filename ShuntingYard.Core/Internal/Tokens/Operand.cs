namespace ShuntingYard.Core.Internal.Tokens;

internal class Operand : Token
{
    public Operand(string value) => Value = value;

    public decimal ToDecimal() => decimal.Parse(Value);
}
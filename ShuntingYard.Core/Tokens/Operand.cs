namespace ShuntingYard.Core.Tokens;

public class Operand : Token
{
    public Operand(string value) => Value = value;

    public decimal ToDecimal() => decimal.Parse(Value);
}
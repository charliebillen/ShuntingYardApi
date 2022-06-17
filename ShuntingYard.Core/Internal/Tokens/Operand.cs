namespace ShuntingYard.Core.Internal.Tokens;

internal class Operand : Token
{
    public decimal Value { get; }

    public Operand(decimal value)
        => Value = value;
}
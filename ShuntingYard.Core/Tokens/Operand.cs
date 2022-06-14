namespace ShuntingYard.Core.Tokens;

public class Operand : Token
{
    public Operand(string value) => Value = value;

    public int ToInt() => int.Parse(Value);
}
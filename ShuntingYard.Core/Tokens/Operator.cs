namespace ShuntingYard.Core.Tokens;

public abstract class Operator : Token
{
    public abstract Operand Apply(Operand left, Operand right);
}
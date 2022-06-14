namespace ShuntingYard.Core.Internal.Tokens;

internal abstract class Operator : Token
{
    public abstract Operand Apply(Operand left, Operand right);
}
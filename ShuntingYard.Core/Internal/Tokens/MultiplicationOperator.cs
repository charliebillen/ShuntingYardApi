namespace ShuntingYard.Core.Internal.Tokens;

internal class MultiplicationOperator : Operator
{
    public MultiplicationOperator() 
        => Precedence = 4;

    public override Operand Apply(Operand left, Operand right) 
        => new(left.Value * right.Value);
}
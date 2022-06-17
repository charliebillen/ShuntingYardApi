namespace ShuntingYard.Core.Internal.Tokens;

internal class AdditionOperator : Operator
{
    public AdditionOperator() 
        => Precedence = 2;

    public override Operand Apply(Operand left, Operand right) 
        => new(left.Value + right.Value);
}
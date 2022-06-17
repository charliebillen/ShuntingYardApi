namespace ShuntingYard.Core.Internal.Tokens;

internal class DivisionOperator : Operator
{
    public DivisionOperator()
        => Precedence = 4;

    public override Operand Apply(Operand left, Operand right) 
        => new(left.Value / right.Value);
}
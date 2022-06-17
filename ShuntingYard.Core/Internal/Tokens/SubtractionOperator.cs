namespace ShuntingYard.Core.Internal.Tokens;

internal class SubtractionOperator : Operator
{
    public SubtractionOperator() => Precedence = 2;

    public override Operand Apply(Operand left, Operand right) 
        => new(left.Value - right.Value);
}
namespace ShuntingYard.Core.Internal.Tokens;

internal class DivisionOperator : Operator
{
    public DivisionOperator(string value)
    {
        Value = value;
        Precedence = 4;
    }

    public override Operand Apply(Operand left, Operand right) 
        => new($"{left.ToDecimal() / right.ToDecimal()}");
}
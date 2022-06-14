namespace ShuntingYard.Core.Internal.Tokens;

internal class SubtractionOperator : Operator
{
    public SubtractionOperator(string value)
    {
        Value = value;
        Precedence = 2;
    }
    
    public override Operand Apply(Operand left, Operand right) 
        => new($"{left.ToDecimal() - right.ToDecimal()}");
}
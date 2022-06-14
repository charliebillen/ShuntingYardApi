namespace ShuntingYard.Core.Tokens;

public class SubtractionOperator : Operator
{
    public SubtractionOperator(string value)
    {
        Value = value;
        Precedence = 2;
    }
    
    public override Operand Apply(Operand left, Operand right) 
        => new($"{left.ToInt() - right.ToInt()}");
}
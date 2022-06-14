namespace ShuntingYard.Core.Tokens;

public class MultiplicationOperator : Operator
{
    public MultiplicationOperator(string value)
    {
        Value = value;
        Precedence = 4;
    }

    public override Operand Apply(Operand left, Operand right) 
        => new($"{left.ToInt() * right.ToInt()}");
}
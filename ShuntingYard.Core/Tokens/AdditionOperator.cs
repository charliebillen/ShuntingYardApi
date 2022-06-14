namespace ShuntingYard.Core.Tokens;

public class AdditionOperator : Operator
{
    public AdditionOperator(string value)
    {
        Value = value;
        Precedence = 2;
    }

    public override Operand Apply(Operand left, Operand right) 
        => new($"{left.ToDecimal() + right.ToDecimal()}");
}
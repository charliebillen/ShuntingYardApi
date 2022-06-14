using ShuntingYard.Core.Internal.Tokens;

namespace ShuntingYard.Core.Internal;

internal static class PostfixCalculator
{
    public static decimal Solve(IEnumerable<Token> calculation)
    {
        var operands = new Stack<Operand>();

        foreach (var token in calculation)
        {
            if (token is Operator op)
            {
                var right = operands.Pop();
                var left = operands.Pop();
                var result = op.Apply(left, right);
                operands.Push(result);
            }
            else
            {
                operands.Push((Operand)token);
            }
        }

        return operands.Pop().ToDecimal();
    }
}

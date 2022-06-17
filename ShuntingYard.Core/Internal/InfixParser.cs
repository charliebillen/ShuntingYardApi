using ShuntingYard.Core.Internal.Tokens;

namespace ShuntingYard.Core.Internal;

internal static class InfixParser
{
    public static IEnumerable<Token> Parse(IEnumerable<Token> input)
    {
        var operatorsOrParens = new Stack<Token>();

        foreach (var token in input)
        {
            switch (token)
            {
                case Operator:
                    while (operatorsOrParens.Any() && token <= operatorsOrParens.Peek())
                    {
                        yield return operatorsOrParens.Pop();
                    }
                    operatorsOrParens.Push(token);
                    break;

                case LeftParen:
                    operatorsOrParens.Push(token);
                    break;

                case RightParen:
                    while (operatorsOrParens.Peek() is not LeftParen)
                    {
                        yield return operatorsOrParens.Pop();
                    }
                    operatorsOrParens.Pop();
                    break;

                default:
                    yield return token;
                    break;
            }
        }

        foreach (var op in operatorsOrParens)
        {
            yield return op;
        }
    }
}